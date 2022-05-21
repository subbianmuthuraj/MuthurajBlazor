using AMuthurajApi.Presentation.ActionFilters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedDto;
using SharedDto.DataTransferObjects;

namespace AMuthurajApi.Presentation.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly UserManager<User> _userManager;
    public TokenController(IServiceManager service, UserManager<User> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    //[HttpPost("refresh")]
    //[ServiceFilter(typeof(ValidationFilterAttribute))]
    //public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    //{
    //    var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

    //    return Ok(tokenDtoToReturn);
    //}

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(
            [FromBody] RefreshTokenDto ReftokenDto)
    {
        if (ReftokenDto == null)
            return BadRequest(new AuthResponseDto
            {
                IsAuthSuccessful = false,
                ErrorMessage = "Invalid client request"
            });

        var principal = _service.AuthenticationService.GetPrincipalFromExpiredToken(ReftokenDto.Token);
        var username = principal.Identity.Name;

        var user = await _userManager.FindByEmailAsync(username);
        if (user == null || user.RefreshToken != ReftokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
            return BadRequest(new AuthResponseDto
            {
                IsAuthSuccessful = false,
                ErrorMessage = "Invalid client request"
            });

        var tokenDto = await _service.AuthenticationService
            .CreateToken(populateExp: true);

        var token = tokenDto.AccessToken;
        user.RefreshToken = tokenDto.RefreshToken;
        await _userManager.UpdateAsync(user);

        return Ok(new AuthResponseDto
        {
            AccessToken = token,
            RefreshToken = user.RefreshToken,
            IsAuthSuccessful = true
        });
    }

}
