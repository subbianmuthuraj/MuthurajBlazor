using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDto.DataTransferObjects
{
    public class TwoFactorVerificationDto
    {
        public string Email { get; set; }
        public string Provider { get; set; }

        [Required(ErrorMessage = "Token is Required")]
        public string TwoFactorToken { get; set; }

    }
}
