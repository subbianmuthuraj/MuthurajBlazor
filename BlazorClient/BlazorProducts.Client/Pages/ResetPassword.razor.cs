using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using SharedDto.DataTransferObjects;

namespace BlazorProducts.Client.Pages
{
    public partial class ResetPassword
    {
        private readonly ResetPasswordDto _resetPassDto = new ResetPasswordDto();
        private bool _showError;
        private bool _showSuccess;
        private IEnumerable<string> _errors;

        [Inject]
        public IAuthenticationService AuthService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

            var queryString = QueryHelpers.ParseQuery(uri.Query);

            if (queryString.TryGetValue("email", out var email) &&
                queryString.TryGetValue("token", out var token))
            {
                _resetPassDto.Email = email;
                _resetPassDto.Token = token;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }


        }

        private async Task Submit()
        {
            _showError = false;
            _showSuccess = false;

            var result = await AuthService.ResetPassword(_resetPassDto);

            if (result.IsResetPasswordSuccessful)
                _showSuccess = true;
            else
            {
                _errors = result.Errors;
                _showError = true;

            }
        }

    }
}
