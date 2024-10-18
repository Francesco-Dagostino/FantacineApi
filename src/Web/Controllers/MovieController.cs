using Application.Interfaces;
using Application.Models;
using Domain.Entities;
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
