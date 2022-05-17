using Entities.Models;
using SharedDto.RequestFeatures;
using SharedDto.DataTransferObjects.Masters;

namespace Service.Contracts
{
    public interface ICountryService
    {
        Task<(IEnumerable<CountryDto> country, MetaData metaData)> GetAllAsync(CountryParameters countryParameters, bool trackChanges);
        Task<CountryDto> GetByIdAsync(int Id, bool trackChanges);
        Task<CountryDto> CreateCountryAsync(CountryCreateDto country);
        Task DeleteCountryAsync(int Id, bool trackChanges);
        Task UpdateCountryAsync(int Id, CountryUpdateDto countryUpdateDto, bool trackChanges);

        Task<(CountryUpdateDto countryToPatch, Country countryEntity)> GetCountryForPatchAsync(int Id, bool trackChanges);
        Task SaveChangesForPatchAsync(CountryUpdateDto countryToPatch, Country countryEntity);
    }
}
