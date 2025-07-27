using System.ComponentModel.DataAnnotations;
using EAMS.Domain.Models.Enums;

namespace EAMS.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.User;

        public string? Jti { get; set; }

        public string? InvitationToken { get; set; }

        public DateTime? InvitationAcceptedAt { get; set; }

        public DateTime? PasswordChangedAt { get; set; }

        public bool PrimaryContact { get; set; } = false;

        // Computed properties
        public string FullName => $"{FirstName} {LastName}";

        public bool IsAdmin => Role >= UserRole.RestrictedAdmin;

        public bool IsManager => Role >= UserRole.Manager;
        
        public bool IsPasswordExpired(int expiryDays = 500)
        {
            if (!PasswordChangedAt.HasValue) return true;
            return DateTime.UtcNow > PasswordChangedAt.Value.AddDays(expiryDays);
        }
    }
    
}