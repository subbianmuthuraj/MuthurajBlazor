using Microsoft.AspNetCore.Identity;
using SharedDto.DataTransferObjects;
using System.Security.Claims;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    Task<TokenDto> CreateToken(bool populateExp);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
