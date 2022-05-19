using SharedDto.DataTransferObjects;

namespace BlazorProducts.Client.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> RegisterUser(UserForRegistrationDto userforRegistrationDto);
    }
}
