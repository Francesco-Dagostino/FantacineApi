using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        List<Movie> GetMoviesByGenre(Genre genre);
        Director GetDirectorById(int directorId);
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);


    }
}
