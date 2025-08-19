using EAMS.Domain.Entities.Enums;

namespace EAMS.API.DTOs
{
    public class AccommodationResponseDto
    {
        public Int64 Id { get; set; }
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
        public bool Inactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AmenityResponseDto> Amenities { get; set; } = new();
    }

    public class AmenityResponseDto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AmenityType AmenityType { get; set; }
        public string HelpText { get; set; } = string.Empty;
    }
}
