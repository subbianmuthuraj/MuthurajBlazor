using AutoMapper;
using Entities.Models;
using SharedDto.DataTransferObjects;
using SharedDto.DataTransferObjects.Masters;

namespace AMuthurajApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

        CreateMap<Employee, EmployeeDto>();

        CreateMap<CompanyForCreationDto, Company>();

        CreateMap<EmployeeForCreationDto, Employee>();

        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        CreateMap<CompanyForUpdateDto, Company>();

        CreateMap<UserForRegistrationDto, User>();

        #region Country
        CreateMap<Country, CountryDto>();
        CreateMap<CountryCreateDto, Country>();
        CreateMap<CountryUpdateDto, Country>();
        CreateMap<CountryUpdateDto, Country>().ReverseMap();
        #endregion Country
        #region ServProvider
        CreateMap<ServProvider, ServProviderDto>();
        CreateMap<ServProviderCreateDto, ServProvider>();
        CreateMap<ServProviderUpdateDto, ServProvider>();
        CreateMap<ServProviderUpdateDto, ServProvider>().ReverseMap();
        #endregion ServProvider

    }
}
