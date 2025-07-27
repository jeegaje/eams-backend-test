using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAMS.Domain.Interfaces;
using EAMS.Domain.Models;
using EAMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EAMS.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}