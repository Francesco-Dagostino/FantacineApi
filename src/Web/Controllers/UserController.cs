using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public ActionResult<UserCreateRequest> Add(UserCreateRequest user)
        {
            try
            {
                var createdUser = _userService.Create(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log para obtener detalles de la excepción.
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            } catch (Exception ex)
            {
                return NotFound($"User with ID {id} not found.");
            }
        }

        [HttpGet("email/{email}")]
        public ActionResult<User> GetByEmail(string email)
        {
            try
            {
                var user = _userService.GetByEmail(email);
                return Ok(user);
            }
            catch (ArgumentNullException)
            {
                return NotFound($"User with Email {email} not found.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateRequest user)
        {
            try
            {
                _userService.UpdateUser(id, user);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
