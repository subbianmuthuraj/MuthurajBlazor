namespace Service.Contracts;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }
    IEmployeeService EmployeeService { get; }
    IAuthenticationService AuthenticationService { get; }

    ICountryService CountryService { get; }
    IServProviderService ServProviderService { get; }

}
