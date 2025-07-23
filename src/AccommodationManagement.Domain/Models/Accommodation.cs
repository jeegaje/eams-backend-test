using System.ComponentModel.DataAnnotations;
using AccommodationManagement.Domain.Models.Enums;

namespace AccommodationManagement.Domain.Models
{
  public class Accommodation : BaseEntity
  {
    [Required]
    [MaxLength(200)]
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

    [MaxLength(200)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(500)]
    [Url]
    public string? Website { get; set; }

    public AccommodationType AccommodationType { get; set; }

    public Density Density { get; set; }

    public Duration Duration { get; set; }

    public bool Inactive { get; set; } = false;
  } 
}