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
        public BaseRepository(AppDBContext dbContext) //Constructor de la clase
        {
            _dbContext = dbContext;
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();    
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
