using EAMS.Domain.Entities;
using EAMS.Domain.Entities.Enums;
using EAMS.Domain.Interfaces;
using EAMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EAMS.Infrastructure.Repositories
{
    public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(EamsDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Accommodation>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(a => !a.Inactive)
                .ToListAsync(cancellationToken);
        }

        public override async Task<Accommodation?> GetByIdAsync(Int64 id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(a => a.Id == id && !a.Inactive, cancellationToken);
        }
    }
}
