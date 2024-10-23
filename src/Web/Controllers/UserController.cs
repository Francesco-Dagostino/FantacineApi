using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize]
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


        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}/UpdateRole")]
        public ActionResult UpdateUserRole([FromRoute] int id, [FromBody] SuperAdminUserUpdateRequest userToUpdate)
        {
            try
            {
                // `id` es el ID del SuperAdmin que está solicitando el cambio
                _userService.UpdateRole(id, userToUpdate);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                return Forbid();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
