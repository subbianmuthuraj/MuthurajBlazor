using Blazored.LocalStorage;
using BlazorProducts.Client.AuthProviders;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SharedDto;
using SharedDto.DataTransferObjects;
using System.Net;
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
        private readonly NavigationManager _navManager;
        public AuthenticationService(HttpClient client,
            AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage,
            NavigationManager navigationManager)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _navManager = navigationManager;
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
            await _localStorage.SetItemAsync("authToken", result.AccessToken);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(
                result.AccessToken);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "bearer", result.AccessToken);

            return new AuthResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");

            var response = await _client.PostAsJsonAsync("token/refresh",
                new RefreshTokenDto
                {
                    Token = token,
                    RefreshToken = refreshToken
                });

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(content, _options);

            await _localStorage.SetItemAsync("authToken", result.AccessToken);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("bearer", result.AccessToken);

            return result.AccessToken;
        }

        public async Task<HttpStatusCode> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            forgotPasswordDto.ClientURI =
                Path.Combine(_navManager.BaseUri, "resetPassword");

            var result = await _client.PostAsJsonAsync("authentication/forgotpassword", forgotPasswordDto);
            return result.StatusCode;
        }

        public async Task<ResetPasswordResponseDto> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var resetresult = await _client.PostAsJsonAsync("authentication/resetpassword", resetPasswordDto);

            var resetContent = await resetresult.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ResetPasswordResponseDto>(resetContent, _options);

            return result;

        }
    }
}
