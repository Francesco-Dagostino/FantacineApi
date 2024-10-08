using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDBContext _dbContext;
        public BaseRepository(AppDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
