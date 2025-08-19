using EAMS.Domain.Entities;

namespace EAMS.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        // Read operations
        Task<T?> GetByIdAsync(Int64 id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        // Write operations
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Int64 id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Int64 id, CancellationToken cancellationToken = default);

        // Unit of work
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}