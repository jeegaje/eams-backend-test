using EAMS.Domain.DTOs;
using EAMS.Domain.Models;

namespace EAMS.Web.Services
{
    public interface IBffService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}