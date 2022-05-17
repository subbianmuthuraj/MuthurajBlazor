using Blazored.Toast.Services;
using BlazorProducts.Client.HttpInterceptor;
using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorProducts.Client.Pages
{
    public partial class CreateCountry : IDisposable
    {
        private Country _country = new Country();
        private EditContext _editContext;
        private bool formInvalid = true;

        [Inject]
        public ICountryHttpRepository countryRepo { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }


        protected override void OnInitialized()
        {
            _editContext = new EditContext(_country);
            _editContext.OnFieldChanged += HandleFieldChanged;
            Interceptor.RegisterEvent();
        }

        private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            formInvalid = !_editContext.Validate();
            StateHasChanged();
        }

        private async Task Create()
        {
            _country.ISActive = 1;
            _country.CreatedById = 2;
            _country.Version_No = 1;
            await countryRepo.CreateCountry(_country);
            ToastService.ShowSuccess($"Action successful. " +
                $"Product \"{_country.CountryName}\" successfully added.");
            _country = new Country();

            _editContext.OnValidationStateChanged += ValidationChanged;
            _editContext.NotifyValidationStateChanged();
        }

        private void ValidationChanged(object? sender, ValidationStateChangedEventArgs e)
        {
            formInvalid = true;
            _editContext.OnFieldChanged -= HandleFieldChanged;
            _editContext = new EditContext(_country);
            _editContext.OnFieldChanged += HandleFieldChanged;
            _editContext.OnValidationStateChanged -= ValidationChanged;


        }

        private void AssignImageUrl(string imgUrl)
            => _country.FlagSVG = imgUrl;
        public void Dispose()
        {
            Interceptor.DisposeEvent();
            _editContext.OnFieldChanged -= HandleFieldChanged;
            _editContext.OnValidationStateChanged -= ValidationChanged;
        }

    }
}
