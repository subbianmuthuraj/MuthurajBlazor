using BlazorProducts.Client.Features;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using SharedDto.RequestFeatures;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorProducts.Client.HttpRepository
{
    public class CountryHttpRepository : ICountryHttpRepository
    {
        private readonly HttpClient _client;
        private readonly NavigationManager _navManager;
        private readonly ApiConfiguration _apiconfiguration;
        private readonly JsonSerializerOptions _options =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public CountryHttpRepository(HttpClient httpClient, NavigationManager navManager, IConfiguration configuration)
        {
            _client = httpClient;
            _navManager = navManager;
            configuration.Bind("ApiConfiguration", _apiconfiguration);
        }

        public async Task CreateCountry(Country country) =>
            await _client.PostAsJsonAsync("countries", country);

        public async Task DeleteCountry(int id)
            => await _client.DeleteAsync(Path.Combine("countries", id.ToString()));


        public async Task<PagingResponse<Country>> GetCountries(CountryParameters countryParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = countryParameters.PageNumber.ToString(),
                ["pageSize"] = countryParameters.PageSize.ToString(),
                ["searchTerm"] = countryParameters.SearchTerm == null ? "" : countryParameters.SearchTerm,
                ["orderBy"] = countryParameters.OrderBy == null ? "" : countryParameters.OrderBy
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("countries", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();

            var pagingResponse = new PagingResponse<Country>
            {
                Items = JsonSerializer.Deserialize<List<Country>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(
                    response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _client.GetFromJsonAsync<Country>($"countries/{id}");
            return country;
        }

        public async Task UpdateCountry(Country country) =>
            await _client.PutAsJsonAsync(Path.Combine("countries", country.Id.ToString()), country);


        public async Task<string> UploadCountryFlagImages(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();

            var imageUrl = Path.Combine(_apiconfiguration.BaseAddress, postContent);
            return imageUrl;
        }
    }
}
