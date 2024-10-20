﻿using Domain.Entities;
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

        User IUserRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}

