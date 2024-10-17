using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDBContext dbContext) : base(dbContext) { }


        /// RESOLVEERR ACA.
        public User GetByEmail(string email)
        {
            return _dbContext.Set<User>() // Puedes acceder directamente porque _dbContext ya está declarado en BaseRepository
                .FirstOrDefault(u => u.Email == email); // Busca por email
        }
    }
}

