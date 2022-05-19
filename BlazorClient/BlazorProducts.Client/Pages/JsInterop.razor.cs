using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorProducts.Client.Pages
{
    public partial class JsInterop
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;
        private string _registrationResult;
        private string _messageDetails;
        private ElementReference _elRef;
        protected async override Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/jsExamples.js");
        }
        public async Task ShowAlertWindow()
        {
            await _jsModule.InvokeVoidAsync("showAlertObject", new { Name = "John", Age = 35 });
        }

        public async Task RegisterEmail()
        {
            _registrationResult = await _jsModule.InvokeAsync<string>("emailRegistraion", "Please Provider your Email");
        }

        private async Task ExtractEmailDetails()
        {
            var emailDetails = await _jsModule.InvokeAsync<EmailDetails>("splitEmailDetails", "Please provide your email");
            if (emailDetails != null)
            {
                _messageDetails = $"Name: {emailDetails.Name}, Server: {emailDetails.Server}, Domain: {emailDetails.Domain}";
            }
            else
            {
                _messageDetails = "Email is not Povided";
            }
        }
        private async Task FocusAndStyleElement() =>
            await _jsModule.InvokeVoidAsync("focusAndStyleElement", _elRef);

    }

    public class EmailDetails
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public string Domain { get; set; }

    }
}
