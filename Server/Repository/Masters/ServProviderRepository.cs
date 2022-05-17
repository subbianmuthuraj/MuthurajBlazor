using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SharedDto.RequestFeatures;

namespace Repository
{
    public class  ServProviderRepository : RepositoryBase<ServProvider>, IServProviderRepository
{
public ServProviderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
{

}
public void CreateServProvider(ServProvider servprovider) => Create(servprovider);


public void DeleteServProvider(ServProvider servprovider) => Delete(servprovider);



public async Task<PagedList<ServProvider>> GetAllAsync(GeneralParameters generalParameters, bool trackChanges)
{
var servproviders = await FindAll(trackChanges)
.Skip ((generalParameters.PageNumber - 1) * generalParameters.PageSize)
.Take (generalParameters.PageSize)
.OrderBy (c => c.Id)
.ToListAsync();

var count = await FindAll(trackChanges).CountAsync();
return new PagedList<ServProvider>(servproviders, count, 
generalParameters.PageNumber, generalParameters.PageSize);
}
public async Task<ServProvider> GetByIdAsync(int Id, bool trackChanges) =>
await FindByCondition(x => x.Id.Equals(Id), trackChanges)
.SingleOrDefaultAsync();
}
}
