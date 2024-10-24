using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Movies
                .Where(m => m.Category == genre)
                .Include(m => m.Director)
                .ToList();  
        }

        public Director GetDirectorById(int directorId)
        {
            return _dbContext.Directors.Find(directorId);
                
        }

        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies
                .Include(m => m.Director)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies
                .Include(m => m.Director) 
                .FirstOrDefault(m => m.MovieId == id);
        }

    }
}
