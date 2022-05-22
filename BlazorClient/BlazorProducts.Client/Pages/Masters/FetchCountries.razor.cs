using BlazorProducts.Client.HttpInterceptor;
using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SharedDto.RequestFeatures;

namespace BlazorProducts.Client.Pages.Masters
{
    public partial class FetchCountries
    {
        private MudTable<Country> _table;
        private CountryParameters _countryParameter = new CountryParameters();
        private readonly int[] _pageSizeOption = { 4, 6, 10 };
        [Inject]
        public ICountryHttpRepository Repository { get; set; }
        private async Task<TableData<Country>> GetServerData(TableState state)
        {
            _countryParameter.PageSize = state.PageSize;
            _countryParameter.PageNumber = state.Page + 1;

            _countryParameter.OrderBy = state.SortDirection == SortDirection.Descending ?
                state.SortLabel + "desc" : state.SortLabel;

            var response = await Repository.GetCountries(_countryParameter);
            return new TableData<Country>
            {
                Items = response.Items,
                TotalItems = response.MetaData.TotalCount
            };
        }

        private void OnSearch(string searchTerm)
        {
            _countryParameter.SearchTerm = searchTerm;
            _table.ReloadServerData();
        }

    }
}
