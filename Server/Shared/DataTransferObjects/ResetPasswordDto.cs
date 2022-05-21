using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDto.DataTransferObjects
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The Password and Compare Password doesnt Match.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
