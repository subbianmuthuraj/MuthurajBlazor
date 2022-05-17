using Entities.Models;
using Microsoft.AspNetCore.Components;
using BlazorProducts.Client.HttpRepository;
namespace BlazorProducts.Client.Pages
{
    public partial class CountryDetails
    {
        public Country country { get; set; } = new Country();
        [Inject]
        public ICountryHttpRepository CountryRepo { get; set; }

        [Parameter]
        public int CountryId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            country = await CountryRepo.GetCountryById(CountryId);
        }


    }
}
