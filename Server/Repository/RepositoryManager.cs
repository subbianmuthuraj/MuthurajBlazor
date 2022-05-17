using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICompanyRepository> _companyRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<IServProviderRepository> _servproviderRepository;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(repositoryContext));
        _servproviderRepository = new Lazy<IServProviderRepository>(() => new ServProviderRepository(repositoryContext));

    }

    public ICompanyRepository Company => _companyRepository.Value;
    public IEmployeeRepository Employee => _employeeRepository.Value;
    public ICountryRepository Country => _countryRepository.Value;
    public IServProviderRepository ServProvider => _servproviderRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
