using System.ComponentModel.DataAnnotations;
using AccommodationManagement.Domain.Models.Enums;

namespace AccommodationManagement.Domain.Models
{
  public class Accommodation : BaseEntity
  {
    public string Name { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string Suburb { get; set; } = string.Empty;

    public string Postcode { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public Region Region { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public AccommodationType AccommodationType { get; set; }

    public Density Density { get; set; }

    public Duration Duration { get; set; }

    public bool Inactive { get; set; } = false;
  } 
}