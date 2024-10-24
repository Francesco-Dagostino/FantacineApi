using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
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
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
            _movieRepository = movieRepository;
        }

        public List<Movie> GetMoviesByGenre(Genre genre)
        {
            return _movieRepository.GetMoviesByGenre(genre);
        }

        public Movie AddMovie(MovieCreateRequest movie)
        {
            var existingDirector = _movieRepository.GetDirectorById(movie.DirectorId);
            if (existingDirector == null)
            {
                throw new Exception("El director con el ID proporcionado no existe.");
            }

            // Crear la nueva película
            var newMovie = new Movie
            {
                Title = movie.Title,
                Category = movie.Category,
                Duration = movie.Duration,
                Description = movie.Description,
                DirectorId = movie.DirectorId // Conectar el director existente
            };

            // Guardar la película en el repositorio
            return _movieRepository.Add(newMovie);
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies(); 
        }

        public List<string> GetGenres() 
        {
            return Enum.GetNames(typeof(Genre)).ToList();
        }

        public void UpdateMovie(int id, MovieUpdateRequest movie)
        {
            var existingMovie = _movieRepository.GetById(id);
            if (existingMovie == null) 
            {
                throw new Exception("Pelicula no encontrada");
            }

            existingMovie.Title = movie.Title;
            existingMovie.Category = movie.Category;
            existingMovie.Duration = movie.Duration;
            existingMovie.Description = movie.Description;
            _movieRepository.Update(existingMovie);
        }

        public void DeleteMovie(int id)
        {
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
