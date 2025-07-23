using AccommodationManagement.Domain.DTOs;

namespace AccommodationManagement.BFF.Services
{
    public interface ICoreApiService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}