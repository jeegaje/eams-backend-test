using System.ComponentModel.DataAnnotations;
using EAMS.Domain.Entities.Enums;

namespace EAMS.API.DTOs
{
    public class AccommodationUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Street is required")]
        [StringLength(200, ErrorMessage = "Street cannot exceed 200 characters")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Suburb is required")]
        [StringLength(100, ErrorMessage = "Suburb cannot exceed 100 characters")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postcode is required")]
        [StringLength(10, ErrorMessage = "Postcode cannot exceed 10 characters")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postcode must be 4 digits")]
        public string Postcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Region is required")]
        public Region Region { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone cannot exceed 20 characters")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? Email { get; set; }

        [Url(ErrorMessage = "Invalid website URL format")]
        [StringLength(200, ErrorMessage = "Website cannot exceed 200 characters")]
        public string? Website { get; set; }

        [Required(ErrorMessage = "Accommodation type is required")]
        public AccommodationType AccommodationType { get; set; }

        [Required(ErrorMessage = "Density is required")]
        public Density Density { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public Duration Duration { get; set; }

        public bool Inactive { get; set; } = false;

        public List<Int64> AmenityIds { get; set; } = new();
    }
}
