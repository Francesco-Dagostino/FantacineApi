using Application.Models;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        Movie AddMovie(MovieCreateRequest movie);
        Movie GetMovieById(int id);
        List<Movie> GetAllMovies();
        void UpdateMovie(int id,MovieUpdateRequest movie);
        void DeleteMovie(int id);
        List<Movie> GetMoviesByGenre(Genre genre);
        //List<Movie> GetMoviesByStatus(MovieStatus status); Disponible | NoDisponible */
    }
}
