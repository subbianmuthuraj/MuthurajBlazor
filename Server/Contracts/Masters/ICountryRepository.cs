using Entities.Models;
using SharedDto.RequestFeatures;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<PagedList<Country>> GetAllAsync(CountryParameters countryParameters, bool trackChanges);
        Task<Country> GetByIdAsync(int Id, bool trackChanges);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
