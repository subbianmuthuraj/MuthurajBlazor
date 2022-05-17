using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using SharedDto.DataTransferObjects.Masters;
using SharedDto.RequestFeatures;

namespace Service
{
    internal sealed class ServProviderService : IServProviderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ServProviderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<ServProviderDto> servprovider, MetaData metaData)> GetAllAsync(GeneralParameters generalParameters, bool trackChanges)
        {
            var returnEntity = await _repository.ServProvider.GetAllAsync(generalParameters, trackChanges);

            var servprovidersWithMetaData = await _repository.ServProvider
            .GetAllAsync(generalParameters, trackChanges);

            var servproviderDto =
            _mapper.Map<IEnumerable<ServProviderDto>>(servprovidersWithMetaData);

            return (servproviders: servproviderDto, metaData: servprovidersWithMetaData.MetaData);
        }


        public async Task<ServProviderDto> GetByIdAsync(int Id, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);

            var returnDto = _mapper.Map<ServProviderDto>(returnEntity);

            return returnDto;
        }

        public async Task<ServProviderDto> CreateServProviderAsync(ServProviderCreateDto servprovider)
        {
            var inputEntity = _mapper.Map<ServProvider>(servprovider);
            servprovider.CreatedById = 1;

            _repository.ServProvider.CreateServProvider(inputEntity);

            await _repository.SaveAsync();

            var entityToReturn = _mapper.Map<ServProviderDto>(inputEntity);

            return entityToReturn;
        }

        public async Task DeleteServProviderAsync(int Id, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);

            _repository.ServProvider.DeleteServProvider(returnEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateServProviderAsync(int Id, ServProviderUpdateDto servproviderUpdateDto, bool trackChanges)
        {
            var returnEntity = await GetEntityAndCheckIfItExists(Id, trackChanges);
            servproviderUpdateDto.LastModifiedbyId = 10;
            servproviderUpdateDto.LastModifiedDt = DateTime.Now;
            servproviderUpdateDto.Version_No = returnEntity.Version_No + 1;
            _mapper.Map(servproviderUpdateDto, returnEntity);

            _repository.SaveAsync();
        }

        public async Task<(ServProviderUpdateDto servproviderToPatch, ServProvider servproviderEntity)> GetServProviderForPatchAsync(int Id, bool trackChanges)
        {
            var returnDb = await GetEntityAndCheckIfItExists(Id, trackChanges);

            var servproviderToPatch = _mapper.Map<ServProviderUpdateDto>(returnDb);

            return (servproviderToPatch: servproviderToPatch, servproviderEntity: returnDb);
        }

        public async Task SaveChangesForPatchAsync(ServProviderUpdateDto servproviderToPatch, ServProvider servproviderEntity)
        {
            _mapper.Map(servproviderToPatch, servproviderEntity);

            await _repository.SaveAsync();
        }

        private async Task<ServProvider> GetEntityAndCheckIfItExists(int Id, bool trackChanges)
        {
            var returnEntity = await _repository.ServProvider.GetByIdAsync(Id, trackChanges);

            if (returnEntity is null)
                throw new NotFoundExceptionWithObjNameAndId("ServProvider", Id);

            return returnEntity;
        }
    }
}
