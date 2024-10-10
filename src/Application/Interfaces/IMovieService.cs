﻿using Domain.Entities;
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
        Movie AddMovie(Movie movie);
        Movie GetMovieById(int id);
        List<Movie> GetAllMovies();
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);

        /* Podria ser tambien
        List<Movie> GetMoviesByGenre(Genre genre);
        List<Movie> GetMoviesByStatus(MovieStatus status); Disponible | NoDisponible */
    }
}