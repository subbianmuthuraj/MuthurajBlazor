using Blazored.LocalStorage;
using BlazorProducts.Client.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;
using SharedDto.DataTransferObjects;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorProducts.Client.HttpRepository
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client,
            AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }



        public async Task<ResponseDto> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var response = await _client.PostAsJsonAsync("authentication/register",
                userForRegistrationDto);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ResponseDto>(content, _options);

                return result;
            }

            return new ResponseDto { IsSuccessfulRegistration = true };
        }

        public async Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication)
        {
            var response = await _client.PostAsJsonAsync("authentication/login",
                userForAuthentication);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<AuthResponseDto>(content, _options);

            if (!response.IsSuccessStatusCode)
            {
                return result;
            }
            await _localStorage.SetItemAsync("authToken", result.Token);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(
                userForAuthentication.Email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
