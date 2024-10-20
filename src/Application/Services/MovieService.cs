﻿using Application.Interfaces;
using Application.Models;
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

        public Movie AddMovie(MovieCreateRequest movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                Category = movie.Category,
                Duration = movie.Duration,
                Description = movie.Description
            };
            return _movieRepository.Add(newMovie);
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
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
