using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{

    public class ServProvider
    {

        [Column("ServProviderId")]
        [Required(ErrorMessage = "ServProviderId Is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ServProviderCode Is Required")]
        public string ServProviderCode { get; set; }

        [Required(ErrorMessage = "ServProviderName Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderName Cannot be more than 200 Characters")]
        public string ServProviderName { get; set; }

        [Required(ErrorMessage = "ServProviderAdd1 Is Required")]
        [MaxLength(500, ErrorMessage = "ServProviderAdd1 Cannot be more than 500 Characters")]
        public string ServProviderAdd1 { get; set; }

        [MaxLength(500, ErrorMessage = "ServProviderAdd2 Cannot be more than 500 Characters")]
        public string? ServProviderAdd2 { get; set; }

        [MaxLength(100, ErrorMessage = "ServProviderState Cannot be more than 100 Characters")]
        public string? ServProviderState { get; set; }

        [Required(ErrorMessage = "ServProviderCity Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderCity Cannot be more than 200 Characters")]
        public string ServProviderCity { get; set; }

        [Required(ErrorMessage = "CountryId Is Required")]

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }


        [Required(ErrorMessage = "ServProviderRegNo Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderRegNo Cannot be more than 100 Characters")]
        public string ServProviderRegNo { get; set; }

        [Required(ErrorMessage = "ServProviderPhone Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderPhone Cannot be more than 100 Characters")]
        public string ServProviderPhone { get; set; }

        [Required(ErrorMessage = "ServProviderEmail Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderEmail Cannot be more than 100 Characters")]
        public string ServProviderEmail { get; set; }

        [Required(ErrorMessage = "ServProviderWebsite Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderWebsite Cannot be more than 100 Characters")]
        public string ServProviderWebsite { get; set; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDt { get; set; } = DateTime.Now;
        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; } = DateTime.Now;
        public int Version_No { get; set; } = 0;
        public int ISActive { get; set; } = 1;

        //public ICollection<Country> country { get; set; }
    }
}
