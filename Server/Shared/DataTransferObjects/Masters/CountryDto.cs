using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SharedDto.DataTransferObjects.Masters
{

    public record CountryDto
    {

        public int Id { get; init; }

        public string CountryCode2 { get; init; }

        public string CountryCode3 { get; init; }

        public string? NumericCode { get; init; }

        public string? CountryName { get; init; }

        public string? OfficialName { get; init; }

        public string? NativeNameOfficial { get; init; }

        public string? NativeNameCommon { get; init; }

        public string? Tld { get; init; }

        public string? CIOC_Code { get; init; }

        public string? CallingCodeRoot { get; init; }

        public string? CallingCodeSuffix { get; init; }

        public string? Capitol { get; init; }

        public string? Region { get; init; }

        public string? SubRegion { get; init; }

        public string? Latitude { get; init; }

        public string? Longitude { get; init; }

        public string? FlagCode { get; init; }

        public string? MapGoogle { get; init; }

        public string? MapOpenStreetMap { get; init; }

        public string? TimrZone { get; init; }

        public string? Continent { get; init; }

        public string? FlagPng { get; init; }

        public string? FlagSVG { get; init; }

        public string? CoatOfArmspng { get; init; }

        public string? CoatOfArmssvg { get; init; }

        public string? StartOfWeek { get; init; }

        public string? CapitalInfolatlng { get; init; }

        public string? PostalCodeformat { get; init; }

        public string? PostalCoderegex { get; init; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDt { get; set; } = DateTime.Now;
        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; } = DateTime.Now;
        public int? Version_No { get; set; } = 0;
        public int? ISActive { get; set; }

    }

    public record CountryCreateDto
    {



        [Required(ErrorMessage = "CountryCode2 Is Required")]
        public string CountryCode2 { get; init; }

        [Required(ErrorMessage = "CountryCode3 Is Required")]
        public string CountryCode3 { get; init; }

        public string? NumericCode { get; init; }

        [Required(ErrorMessage = "CountryName Is Required")]
        [MaxLength(255, ErrorMessage = "CountryName Cannot be more than 255 Characters")]
        public string? CountryName { get; init; }

        public string? OfficialName { get; init; }

        public string? NativeNameOfficial { get; init; }

        public string? NativeNameCommon { get; init; }

        public string? Tld { get; init; }

        public string? CIOC_Code { get; init; }

        public string? CallingCodeRoot { get; init; }

        public string? CallingCodeSuffix { get; init; }

        public string? Capitol { get; init; }

        [Required(ErrorMessage = "Region Is Required")]
        [MaxLength(255, ErrorMessage = "Region Cannot be more than 255 Characters")]
        public string? Region { get; init; }

        public string? SubRegion { get; init; }

        public string? Latitude { get; init; }

        public string? Longitude { get; init; }

        public string? FlagCode { get; init; }

        public string? MapGoogle { get; init; }

        public string? MapOpenStreetMap { get; init; }

        public string? TimrZone { get; init; }

        public string? Continent { get; init; }

        public string? FlagPng { get; init; }

        public string? FlagSVG { get; init; }

        public string? CoatOfArmspng { get; init; }

        public string? CoatOfArmssvg { get; init; }

        public string? StartOfWeek { get; init; }

        public string? CapitalInfolatlng { get; init; }

        public string? PostalCodeformat { get; init; }

        public string? PostalCoderegex { get; init; }

        public int? CreatedById { get; set; }
        public DateTime? CreatedDt { get; set; } = DateTime.Now;
        public int? Version_No { get; set; } = 1;
        public int? ISActive { get; set; } = 1;

    }

    public record CountryUpdateDto
    {


        [Required(ErrorMessage = "CountryCode2 Is Required")]
        public string CountryCode2 { get; init; }

        [Required(ErrorMessage = "CountryCode3 Is Required")]
        public string CountryCode3 { get; init; }

        public string? NumericCode { get; init; }

        [Required(ErrorMessage = "CountryName Is Required")]
        [MaxLength(255, ErrorMessage = "CountryName Cannot be more than 255 Characters")]
        public string? CountryName { get; init; }

        public string? OfficialName { get; init; }

        public string? NativeNameOfficial { get; init; }

        public string? NativeNameCommon { get; init; }

        public string? Tld { get; init; }

        public string? CIOC_Code { get; init; }

        public string? CallingCodeRoot { get; init; }

        public string? CallingCodeSuffix { get; init; }

        public string? Capitol { get; init; }

        [Required(ErrorMessage = "Region Is Required")]
        [MaxLength(255, ErrorMessage = "Region Cannot be more than 255 Characters")]
        public string? Region { get; init; }

        public string? SubRegion { get; init; }

        public string? Latitude { get; init; }

        public string? Longitude { get; init; }

        public string? FlagCode { get; init; }

        public string? MapGoogle { get; init; }

        public string? MapOpenStreetMap { get; init; }

        public string? TimrZone { get; init; }

        public string? Continent { get; init; }

        public string? FlagPng { get; init; }

        public string? FlagSVG { get; init; }

        public string? CoatOfArmspng { get; init; }

        public string? CoatOfArmssvg { get; init; }

        public string? StartOfWeek { get; init; }

        public string? CapitalInfolatlng { get; init; }

        public string? PostalCodeformat { get; init; }

        public string? PostalCoderegex { get; init; }

        public int? LastModifiedbyId { get; set; }
        public DateTime? LastModifiedDt { get; set; } = DateTime.Now;
        public int? Version_No { get; set; } = 2;
        public int? ISActive { get; set; }

    }
}
