using AccommodationManagement.Domain.DTOs;

namespace AccommodationManagement.BFF.Services
{
    public interface ICoreApiService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}