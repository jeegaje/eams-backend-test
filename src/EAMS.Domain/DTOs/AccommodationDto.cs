using System.ComponentModel.DataAnnotations;
using EAMS.Domain.Constants;
using EAMS.Domain.Models.Enums;

namespace EAMS.Domain.DTOs
{
    public class AccommodationDto
    {
    /// <summary>
    /// DTO for accommodation information
    /// </summary>
    [Required]
    [MaxLength(AppConstants.Validation.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Suburb { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string Postcode { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string State { get; set; } = string.Empty;

    public Region Region { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(AppConstants.Validation.MaxEmailLength)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(500)]
    [Url]
    public string? Website { get; set; }

    [EnumDataType(typeof(AccommodationType))]
    public AccommodationType AccommodationType { get; set; }

    [EnumDataType(typeof(Density))]
    public Density Density { get; set; }

    [EnumDataType(typeof(Duration))]
    public Duration Duration { get; set; }

    public bool Inactive { get; set; } = false;
    }
}