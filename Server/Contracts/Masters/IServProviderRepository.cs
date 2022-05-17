using Entities.Models;
using SharedDto.RequestFeatures;

namespace Contracts
{
    public interface IServProviderRepository
    {
        Task<PagedList<ServProvider>> GetAllAsync(GeneralParameters generalParameters, bool trackChanges);
        Task<ServProvider> GetByIdAsync(int Id, bool trackChanges);
        void CreateServProvider(ServProvider servprovider);
        void DeleteServProvider(ServProvider servprovider);
    }
}
