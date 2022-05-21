using AMuthurajApi.Presentation.ActionFilters;
using EmailService;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Service.Contracts;
using SharedDto;
using SharedDto.DataTransferObjects;
using SharedDto.DataTransferObjects.Masters;

namespace AMuthurajApi.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly UserManager<User> _userManager;
    private readonly IEmailSender _emailSender;

    public AuthenticationController(IServiceManager service,
        UserManager<User> userManager,
        IEmailSender emailSender)
    {
        _service = service;
        _userManager = userManager;
        _emailSender = emailSender;
    }

    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new ResponseDto { Errors = errors });
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
    {

        if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
            return Unauthorized(new AuthResponseDto
            {
                ErrorMessage = "Invalid Authentication"

            });
        var tokenDto = await _service.AuthenticationService
            .CreateToken(populateExp: true);

        return Ok(tokenDto);
    }

    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        var user = await _userManager.FindByNameAsync(forgotPasswordDto.Email);
        if (user == null)
            return BadRequest("Invalid Request");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var param = new Dictionary<string, string>
        {
            {"token", token },
            {"email", forgotPasswordDto.Email }
        };

        var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);

        var message = new Message(new string[] { user.Email }, "Reset Password Token from Blzor Product",
            callback, null);

        await _emailSender.SendEmailAsync(message);

        return Ok();
    }
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(
        [FromBody] ResetPasswordDto resetPasswordDto)
    {
        var errorResponse = new ResetPasswordResponseDto
        {
            Errors = new string[] { "Reset Password Failed" }
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(errorResponse);
        }

        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

        if (user == null)
            return BadRequest(errorResponse);

        var resetPassResult = await _userManager.ResetPasswordAsync(user,
            resetPasswordDto.Token, resetPasswordDto.Password);

        if (!resetPassResult.Succeeded)
        {
            var errors = resetPassResult.Errors.Select(e => e.Description);
            return BadRequest(new ResetPasswordResponseDto { Errors = errors });
        }

        return Ok(new ResetPasswordResponseDto { IsResetPasswordSuccessful = true });
    }


}
