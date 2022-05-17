using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using SharedDto.DataTransferObjects;

namespace Contracts;

public interface IEmployeeLinks
{
	LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto,
		string fields, Guid companyId, HttpContext httpContext);
}
