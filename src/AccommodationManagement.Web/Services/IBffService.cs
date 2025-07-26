using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.Domain.Models;

namespace AccommodationManagement.Web.Services
{
    public interface IBffService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}