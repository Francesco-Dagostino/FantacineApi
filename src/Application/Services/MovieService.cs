using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IBaseRepository<Movie> _movieRepository;
        public MovieService(IBaseRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie AddMovie(Movie movie)
        {
            return _movieRepository.Add(movie);
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            // Lógica para eliminar una película por ID
            var movie = _movieRepository.GetById(id);
            if (movie != null)
            {
                _movieRepository.Delete(movie);
            }
            else
            {
                throw new Exception("Película no encontrada");
            }
        }
    }
}
