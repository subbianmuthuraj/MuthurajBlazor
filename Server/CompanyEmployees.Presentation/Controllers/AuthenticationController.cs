using AMuthurajApi.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedDto.DataTransferObjects;
using SharedDto.DataTransferObjects.Masters;

namespace AMuthurajApi.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service) => _service = service;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
        //if (!result.Succeeded)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.TryAddModelError(error.Code, error.Description);
        //    }
        //    return BadRequest(ModelState);
        //}
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new ResponseDto { Errors = errors });
        }
        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();

        var tokenDto = await _service.AuthenticationService
            .CreateToken(populateExp: true);

        return Ok(tokenDto);
    }
}
