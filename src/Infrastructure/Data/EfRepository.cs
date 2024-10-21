using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        protected readonly AppDBContext _dbContext;
        public EfRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
