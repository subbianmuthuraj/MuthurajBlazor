namespace Contracts;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    ICountryRepository Country { get; }
    IServProviderRepository ServProvider { get; }
    Task SaveAsync();
}
