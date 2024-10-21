using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDBContext dbContext) : base(dbContext) { }

        public List<Movie> GetMoviesByGenre(Genre genre)
        {
            return _dbContext.Movies.Where(m => m.Category == genre).ToList();
        }
    }
}
