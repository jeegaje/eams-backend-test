using EAMS.Domain.DTOs;

namespace EAMS.BFF.Services
{
    public interface ICoreApiService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}