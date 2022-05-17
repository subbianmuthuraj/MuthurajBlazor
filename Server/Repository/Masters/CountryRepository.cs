using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using SharedDto.RequestFeatures;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateCountry(Country country) => Create(country);


        public void DeleteCountry(Country country) => Delete(country);



        public async Task<PagedList<Country>> GetAllAsync(CountryParameters countryParameters,
            bool trackChanges)
        {
            var countries = await FindAll(trackChanges)
                .SearchByName(countryParameters.SearchTerm)
                .Sort(countryParameters.OrderBy)
                .ToListAsync();
            //var count = countries.Count();

            //var count = await FindAll(trackChanges).CountAsync();
            //return new PagedList<Country>(countries, count,
            //countryParameters.PageNumber, countryParameters.PageSize);
            return PagedList<Country>.ToPagedList(countries, countryParameters.PageNumber,
                countryParameters.PageSize);

        }
        public async Task<Country> GetByIdAsync(int Id, bool trackChanges) =>
        await FindByCondition(x => x.Id.Equals(Id), trackChanges)
        .SingleOrDefaultAsync();
    }
}
