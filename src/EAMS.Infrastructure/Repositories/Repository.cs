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
    }
}