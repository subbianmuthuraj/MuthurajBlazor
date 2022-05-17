using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{

    public class Country
    {

        [Column("CountryId")]
        [Required(ErrorMessage = "CountryId Is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CountryCode2 Is Required")]
        public string CountryCode2 { get; set; }

        [Required(ErrorMessage = "CountryCode3 Is Required")]
        public string CountryCode3 { get; set; }

        public string? NumericCode { get; set; }

        [Required(ErrorMessage = "CountryName Is Required")]
        [MaxLength(255, ErrorMessage = "CountryName Cannot be more than 255 Characters")]
        public string CountryName { get; set; }

        [MaxLength(255, ErrorMessage = "OfficialName Cannot be more than 255 Characters")]
        public string? OfficialName { get; set; }

        [MaxLength(255, ErrorMessage = "NativeNameOfficial Cannot be more than 255 Characters")]
        public string? NativeNameOfficial { get; set; }

        [MaxLength(255, ErrorMessage = "NativeNameCommon Cannot be more than 255 Characters")]
        public string? NativeNameCommon { get; set; }

        [MaxLength(255, ErrorMessage = "Tld Cannot be more than 255 Characters")]
        public string? Tld { get; set; }

        [MaxLength(10, ErrorMessage = "CIOC_Code Cannot be more than 10 Characters")]
        public string? CIOC_Code { get; set; }

        [MaxLength(10, ErrorMessage = "CallingCodeRoot Cannot be more than 10 Characters")]
        public string? CallingCodeRoot { get; set; }

        [MaxLength(255, ErrorMessage = "CallingCodeSuffix Cannot be more than 255 Characters")]
        public string? CallingCodeSuffix { get; set; }

        [MaxLength(255, ErrorMessage = "Capitol Cannot be more than 255 Characters")]
        public string? Capitol { get; set; }

        [Required(ErrorMessage = "Region Is Required")]
        [MaxLength(255, ErrorMessage = "Region Cannot be more than 255 Characters")]
        public string Region { get; set; }

        [MaxLength(255, ErrorMessage = "SubRegion Cannot be more than 255 Characters")]
        public string? SubRegion { get; set; }

        [MaxLength(50, ErrorMessage = "Latitude Cannot be more than 50 Characters")]
        public string? Latitude { get; set; }

        [MaxLength(50, ErrorMessage = "Longitude Cannot be more than 50 Characters")]
        public string? Longitude { get; set; }

        [MaxLength(50, ErrorMessage = "FlagCode Cannot be more than 50 Characters")]
        public string? FlagCode { get; set; }

        [MaxLength(255, ErrorMessage = "MapGoogle Cannot be more than 255 Characters")]
        public string? MapGoogle { get; set; }

        [MaxLength(255, ErrorMessage = "MapOpenStreetMap Cannot be more than 255 Characters")]
        public string? MapOpenStreetMap { get; set; }

        [MaxLength(255, ErrorMessage = "TimrZone Cannot be more than 255 Characters")]
        public string? TimrZone { get; set; }

        [MaxLength(255, ErrorMessage = "Continent Cannot be more than 255 Characters")]
        public string? Continent { get; set; }

        [MaxLength(255, ErrorMessage = "FlagPng Cannot be more than 255 Characters")]
        public string? FlagPng { get; set; }

        [MaxLength(255, ErrorMessage = "FlagSVG Cannot be more than 255 Characters")]
        public string? FlagSVG { get; set; }

        [MaxLength(255, ErrorMessage = "CoatOfArmspng Cannot be more than 255 Characters")]
        public string? CoatOfArmspng { get; set; }

        [MaxLength(255, ErrorMessage = "CoatOfArmssvg Cannot be more than 255 Characters")]
        public string? CoatOfArmssvg { get; set; }

        [MaxLength(20, ErrorMessage = "StartOfWeek Cannot be more than 20 Characters")]
        public string? StartOfWeek { get; set; }

        [MaxLength(50, ErrorMessage = "CapitalInfolatlng Cannot be more than 50 Characters")]
        public string? CapitalInfolatlng { get; set; }

        [MaxLength(255, ErrorMessage = "PostalCodeformat Cannot be more than 255 Characters")]
        public string? PostalCodeformat { get; set; }

        [MaxLength(255, ErrorMessage = "PostalCoderegex Cannot be more than 255 Characters")]
        public string? PostalCoderegex { get; set; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDt { get; set; } = DateTime.Now;
        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; } = DateTime.Now;
        public int Version_No { get; set; } = 0;
        public int ISActive { get; set; } = 1;

    }
}
