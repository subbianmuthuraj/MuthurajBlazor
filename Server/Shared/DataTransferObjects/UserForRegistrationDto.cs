using System.ComponentModel.DataAnnotations;

namespace SharedDto.DataTransferObjects;

public record UserForRegistrationDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password should match")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Email is Required")]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string ClientURI { get; set; }
    //public ICollection<string>? Roles { get; set; } 
}
