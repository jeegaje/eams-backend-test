using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationManagement.Domain.Interfaces;
using AccommodationManagement.Domain.Models;
using AccommodationManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccommodationManagement.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}