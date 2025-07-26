using AccommodationManagement.Domain.Interfaces;
using AccommodationManagement.Domain.Models;

namespace AccommodationManagement.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}