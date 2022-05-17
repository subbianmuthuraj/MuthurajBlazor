using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SharedDto.DataTransferObjects.Masters
{

    public record ServProviderDto
    {

        public int Id { get; init; }

        public string ServProviderCode { get; init; }

        public string ServProviderName { get; init; }

        public string ServProviderAdd1 { get; init; }

        public string? ServProviderAdd2 { get; init; }

        public string? ServProviderState { get; init; }

        public string? ServProviderCity { get; init; }

        public int? CountryId { get; init; }

        public string? ServProviderRegNo { get; init; }

        public string? ServProviderPhone { get; init; }

        public string? ServProviderEmail { get; init; }

        public string? ServProviderWebsite { get; init; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDt { get; set; } = DateTime.Now;
        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; } = DateTime.Now;
        public int? Version_No { get; set; } = 0;
        public int? ISActive { get; set; }

    }

    public record ServProviderCreateDto
    {



        [Required(ErrorMessage = "ServProviderCode Is Required")]
        public string ServProviderCode { get; init; }

        [Required(ErrorMessage = "ServProviderName Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderName Cannot be more than 200 Characters")]
        public string ServProviderName { get; init; }

        [Required(ErrorMessage = "ServProviderAdd1 Is Required")]
        [MaxLength(500, ErrorMessage = "ServProviderAdd1 Cannot be more than 500 Characters")]
        public string ServProviderAdd1 { get; init; }

        public string? ServProviderAdd2 { get; init; }

        public string? ServProviderState { get; init; }

        [Required(ErrorMessage = "ServProviderCity Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderCity Cannot be more than 200 Characters")]
        public string? ServProviderCity { get; init; }

        [Required(ErrorMessage = "CountryId Is Required")]
        public int? CountryId { get; init; }

        [Required(ErrorMessage = "ServProviderRegNo Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderRegNo Cannot be more than 100 Characters")]
        public string? ServProviderRegNo { get; init; }

        [Required(ErrorMessage = "ServProviderPhone Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderPhone Cannot be more than 100 Characters")]
        public string? ServProviderPhone { get; init; }

        [Required(ErrorMessage = "ServProviderEmail Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderEmail Cannot be more than 100 Characters")]
        public string? ServProviderEmail { get; init; }

        [Required(ErrorMessage = "ServProviderWebsite Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderWebsite Cannot be more than 100 Characters")]
        public string? ServProviderWebsite { get; init; }

        public int? CreatedById { get; set; }

    }

    public record ServProviderUpdateDto
    {


        [Required(ErrorMessage = "ServProviderCode Is Required")]
        public string ServProviderCode { get; init; }

        [Required(ErrorMessage = "ServProviderName Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderName Cannot be more than 200 Characters")]
        public string ServProviderName { get; init; }

        [Required(ErrorMessage = "ServProviderAdd1 Is Required")]
        [MaxLength(500, ErrorMessage = "ServProviderAdd1 Cannot be more than 500 Characters")]
        public string ServProviderAdd1 { get; init; }

        public string? ServProviderAdd2 { get; init; }

        public string? ServProviderState { get; init; }

        [Required(ErrorMessage = "ServProviderCity Is Required")]
        [MaxLength(200, ErrorMessage = "ServProviderCity Cannot be more than 200 Characters")]
        public string? ServProviderCity { get; init; }

        [Required(ErrorMessage = "CountryId Is Required")]
        public int? CountryId { get; init; }

        [Required(ErrorMessage = "ServProviderRegNo Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderRegNo Cannot be more than 100 Characters")]
        public string? ServProviderRegNo { get; init; }

        [Required(ErrorMessage = "ServProviderPhone Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderPhone Cannot be more than 100 Characters")]
        public string? ServProviderPhone { get; init; }

        [Required(ErrorMessage = "ServProviderEmail Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderEmail Cannot be more than 100 Characters")]
        public string? ServProviderEmail { get; init; }

        [Required(ErrorMessage = "ServProviderWebsite Is Required")]
        [MaxLength(100, ErrorMessage = "ServProviderWebsite Cannot be more than 100 Characters")]
        public string? ServProviderWebsite { get; init; }

        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; }
        public int? Version_No { get; set; }
        public int? ISActive { get; set; }

    }
}
