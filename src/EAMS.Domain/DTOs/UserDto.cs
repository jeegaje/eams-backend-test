using System.ComponentModel.DataAnnotations;
using EAMS.Domain.Models.Enums;

namespace EAMS.Domain.DTOs
{
    public class UserDto
    {
        /// <summary>
        /// DTO for user information
        /// </summary>
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; } = UserRole.User;
        public bool PrimaryContact { get; set; } = false;
    }
}