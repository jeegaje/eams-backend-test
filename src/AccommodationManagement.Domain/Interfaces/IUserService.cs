using AccommodationManagement.Domain.Models;

namespace AccommodationManagement.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}