using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _service;
        public DirectorController(IDirectorService service)
        {
            _service = service;
        }

        [HttpPost("Agregar Director")]
        public ActionResult<Director> AddDirector([FromBody] DirectorCreateRequest director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Esto devuelve los errores de validación si el modelo es inválido
            }

            return Ok(_service.AddDirector(director));
        }

        [HttpGet("{id}")]
        public ActionResult<Director> GetDirectorByID(int id) 
        {
            var director = _service.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpGet("All Directors")]
        public ActionResult<List<Director>> GetAllDirector()
        {
            return Ok(_service.GetAllDirector());
        }

        [HttpPut("Update/{id}")]
        public ActionResult UpdateDirector([FromRoute]int id,[FromBody]DirectorUpdateRequest director ) 
        {
      
            try 
            {
                _service.UpdateDirector(id, director);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteDirector(int id)
        {
            try
            {
                _service.DeleteDirector(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
