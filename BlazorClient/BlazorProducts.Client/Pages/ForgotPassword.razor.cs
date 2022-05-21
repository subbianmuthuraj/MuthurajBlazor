using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using SharedDto;
using System.Net;

namespace BlazorProducts.Client.Pages
{
    public partial class ForgotPassword
    {
        private ForgotPasswordDto _forgotPassDto = new ForgotPasswordDto();
        private bool _showSuccess;
        private bool _showError;

        [Inject]
        public IAuthenticationService AuthService { get; set; }

        private async Task Submit()
        {
            _showError = false;
            _showSuccess = false;

            var result = await AuthService.ForgotPassword(_forgotPassDto);

            if (result == HttpStatusCode.OK)
                _showSuccess = true;
            else
                _showError = true;


        }

    }
}
