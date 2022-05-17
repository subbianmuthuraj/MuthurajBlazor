using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using SharedDto.DataTransferObjects.Masters;
using SharedDto.RequestFeatures;

namespace Service
{
    internal sealed class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CountryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<CountryDto> country, MetaData metaData)> GetAllAsync(CountryParameters countryParameters, bool trackChanges)
        {
            var returnEntity = await _repository.Country.GetAllAsync(countryParameters, trackChanges);

            var countriesWithMetaData = await _repository.Country
            .GetAllAsync(countryParameters, trackChanges);

            var countryDto =
            _mapper.Map<IEnumerable<CountryDto>>(countriesWithMetaData);

            return (countries: countryDto, metaData: countriesWithMetaData.MetaData);
        }


        public async Task<CountryDto> GetByIdAsync(int Id, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);

            var returnDto = _mapper.Map<CountryDto>(returnEntity);

            return returnDto;
        }

        public async Task<CountryDto> CreateCountryAsync(CountryCreateDto country)
        {
            var inputEntity = _mapper.Map<Country>(country);

            _repository.Country.CreateCountry(inputEntity);

            await _repository.SaveAsync();

            var entityToReturn = _mapper.Map<CountryDto>(inputEntity);

            return entityToReturn;
        }

        public async Task DeleteCountryAsync(int Id, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);

            _repository.Country.DeleteCountry(returnEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateCountryAsync(int Id, CountryUpdateDto countryUpdateDto, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);
            countryUpdateDto.LastModifiedbyId = 10;
            countryUpdateDto.LastModifiedDt = DateTime.Now;
            countryUpdateDto.Version_No = returnEntity.Version_No + 1;
            _mapper.Map(countryUpdateDto, returnEntity);

            _repository.SaveAsync();
        }

        public async Task<(CountryUpdateDto countryToPatch, Country countryEntity)> GetCountryForPatchAsync(int Id, bool trackChanges)
        {
            var returnDb = await GetEntityAndCheckIfItExists(Id, trackChanges);

            var countryToPatch = _mapper.Map<CountryUpdateDto>(returnDb);

            return (countryToPatch: countryToPatch, countryEntity: returnDb);
        }

        public async Task SaveChangesForPatchAsync(CountryUpdateDto countryToPatch, Country countryEntity)
        {
            _mapper.Map(countryToPatch, countryEntity);

            await _repository.SaveAsync();
        }

        private async Task<Country> GetEntityAndCheckIfItExists(int Id, bool trackChanges)
        {
            var returnEntity = await _repository.Country.GetByIdAsync(Id, trackChanges);

            if (returnEntity is null)
                throw new NotFoundExceptionWithObjNameAndId("Country", Id);

            return returnEntity;
        }
    }
}
