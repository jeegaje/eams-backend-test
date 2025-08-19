using EAMS.Domain.Interfaces;
using EAMS.Domain.Entities;
using EAMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EAMS.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EamsDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(EamsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(Int64 id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            var result = await _dbSet.AddAsync(entity, cancellationToken);
            return result.Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = await GetByIdAsync(entity.Id, cancellationToken);
            if (existingEntity == null)
                throw new InvalidOperationException($"Entity with ID {entity.Id} not found.");

            entity.UpdatedAt = DateTime.UtcNow;
            entity.CreatedAt = existingEntity.CreatedAt; // Preserve original creation date

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return existingEntity;
        }

        public virtual async Task DeleteAsync(Int64 id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null)
                throw new InvalidOperationException($"Entity with ID {id} not found.");

            _dbSet.Remove(entity);
        }

        public virtual async Task<bool> ExistsAsync(Int64 id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}