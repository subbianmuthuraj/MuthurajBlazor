using Microsoft.AspNetCore.Http;
using SharedDto.RequestFeatures;

namespace Entities.LinkModels;

public record LinkParameters(EmployeeParameters EmployeeParameters, HttpContext Context);
