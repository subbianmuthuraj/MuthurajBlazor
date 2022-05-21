﻿using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using SharedDto.DataTransferObjects;

namespace BlazorProducts.Client.Pages
{
    public partial class Login
    {
        private UserForAuthenticationDto _userForAuthentication =
            new UserForAuthenticationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        public async Task ExecuteLogin()
        {
            ShowAuthError = false;

            var result = await AuthenticationService.Login(_userForAuthentication);

            if (result.Is2StepVerificationRequired)
            {
                var queryParams = new Dictionary<string, string>()
                {
                    ["Provider"] = result.Provider,
                    ["email"] = _userForAuthentication.Email
                };

                NavigationManager.NavigateTo(QueryHelpers.AddQueryString(
                    "/twostepverification", queryParams));
            }
            else if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
