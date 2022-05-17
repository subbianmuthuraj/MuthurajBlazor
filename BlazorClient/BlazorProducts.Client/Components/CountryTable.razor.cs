using BlazorProducts.Client.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Components
{
    public partial class CountryTable
    {
        [Parameter]
        public List<Country> Countries { get; set; }

        [Parameter]
        public EventCallback<int> OnDelete { get; set; }

        private Confirmation _confirmation;
        private int _countryToDelete;

        private void CallConfirmationModel(int id)
        {
            _countryToDelete = id;
            _confirmation.Show();
        }

        private async Task DeleteCountry()
        {
            _confirmation.Hide();
            await OnDelete.InvokeAsync(_countryToDelete);

        }
    }
}
