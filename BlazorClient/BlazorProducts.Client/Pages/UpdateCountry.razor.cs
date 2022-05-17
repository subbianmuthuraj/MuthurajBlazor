using Blazored.Toast.Services;
using BlazorProducts.Client.HttpInterceptor;
using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
namespace BlazorProducts.Client.Pages
{
    public partial class UpdateCountry : IDisposable
    {

        private Country _country;
        private EditContext _editContext;
        private bool formInvalid = true;

        [Inject]
        public ICountryHttpRepository CountryRepo { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _country = await CountryRepo.GetCountryById(Id);
            _editContext = new EditContext(_country);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Update()
        {
            await CountryRepo.UpdateCountry(_country);

            ToastService.ShowSuccess($"Action successful. " +
                $"Product \"{_country.CountryName}\" successfully updated.");
        }

        private void AssignImageUrl(string imgUrl)
            => _country.FlagSVG = imgUrl;

        public void Dispose()
        {
            Interceptor.DisposeEvent();
            _editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
