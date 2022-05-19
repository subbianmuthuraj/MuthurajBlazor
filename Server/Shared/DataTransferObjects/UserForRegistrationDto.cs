using System.ComponentModel.DataAnnotations;

namespace SharedDto.DataTransferObjects;

public record UserForRegistrationDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; }
    [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password should match")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Email is Required")]
    public string Email { get; init; }
    public string? PhoneNumber { get; init; }
    public ICollection<string>? Roles { get; init; }
}
