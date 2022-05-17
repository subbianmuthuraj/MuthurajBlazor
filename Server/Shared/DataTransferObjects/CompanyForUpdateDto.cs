namespace SharedDto.DataTransferObjects;

public record CompanyForUpdateDto : CompanyForManipulationDto
{
    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}
