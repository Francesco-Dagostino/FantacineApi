using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieRepository;
        public MovieController(IMovieService movieRepository) 
        { 
            _movieRepository = movieRepository;
        }
        [HttpPost("Add Movie")]
        public ActionResult<Movie> AddMovie([FromBody] MovieCreateRequest movie) 
        {

            return Ok(_movieRepository.AddMovie(movie));
            
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id) 
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null) 
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("Todos los generos")]
        public ActionResult<List<string>> GetGenres()
        {
            var genres = _movieRepository.GetGenres();
            return Ok(genres);
        }


        [HttpGet("Filtrar por genero/{genre}")]
        public ActionResult<List<Movie>> GetMoviesByGenre(Genre genre)
        {
            var movies = _movieRepository.GetMoviesByGenre(genre);
            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found for the specified genre.");
            }
            return Ok(movies);
        }

        [HttpGet("All Movies")]
        public ActionResult<List<Movie>> GetAllMovies() 
        { 
            return Ok(_movieRepository.GetAllMovies());
        }

        [HttpPut("Update/{id}")]
        public ActionResult UpdateMovie([FromRoute] int id,[FromBody] MovieUpdateRequest movie) 
        {
            try
            {
                _movieRepository.UpdateMovie(id, movie);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteMovie(int id) 
        { 
            try
            {
                _movieRepository.DeleteMovie(id);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

    }
}
