using Entities.Models;
using SharedDto.RequestFeatures;
using SharedDto.DataTransferObjects.Masters;

namespace Service.Contracts
{
    public interface IServProviderService
    {
        Task<(IEnumerable<ServProviderDto> servprovider, MetaData metaData)> GetAllAsync(GeneralParameters generalParameters, bool trackChanges);
        Task<ServProviderDto> GetByIdAsync(int Id, bool trackChanges);
        Task<ServProviderDto> CreateServProviderAsync(ServProviderCreateDto servprovider);
        Task DeleteServProviderAsync(int Id, bool trackChanges);
        Task UpdateServProviderAsync(int Id, ServProviderUpdateDto servproviderUpdateDto, bool trackChanges);

        Task<(ServProviderUpdateDto servproviderToPatch, ServProvider servproviderEntity)> GetServProviderForPatchAsync(int Id, bool trackChanges);
        Task SaveChangesForPatchAsync(ServProviderUpdateDto servproviderToPatch, ServProvider servproviderEntity);
    }
}
