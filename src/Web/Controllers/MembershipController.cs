using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Domain.Enums;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _serviceMembership;
        private readonly IUserService _userService; // Servicio para verificar usuarios

        public MembershipController(IMembershipService serviceMembership, IUserService userService)
        {
            _serviceMembership = serviceMembership;
            _userService = userService; // Inyección del servicio de usuario
        }

        [HttpPost("AddMembership")]
        public ActionResult<Membership> AsignarMembership([FromBody] Membership membership)
        {
            // Verificar si el usuario existe
            var user = _userService.GetUserById(membership.UserId);
            if (user == null)
            {
                return NotFound("El usuario no existe.");
            }

            // Asignar el tipo de suscripción
            membership.Type = SubscriptionType.Active; // O Desactive según el caso

            // Convertir Membership a MembershipCreateRequest
            var membershipRequest = new MembershipCreateRequest
            {
                Date = membership.Date,
                Payment = membership.Payment,
                Type = membership.Type,
                UserId = membership.UserId
            };

            // Llamar al servicio con el request correcto
            _serviceMembership.AddMembership(membershipRequest);

            return Ok(membership);
        }

        [HttpGet("{id}")]
        public ActionResult<Membership> GetMembershipByID(int id)
        {
            var membership = _serviceMembership.GetMembershipById(id);
            if (membership == null)
            {
                return NotFound();
            }
            return Ok(membership);
        }

        [HttpDelete("Client Delete/{id}")]
        public ActionResult DeleteMembership(int id)
        {
            try
            {
                var membership = _serviceMembership.GetMembershipById(id);
                if (membership == null)
                {
                    return NotFound("Membresía no encontrada.");
                }

                // Verificar si la membresía está activa
                if (membership.Type == SubscriptionType.Active)
                {
                    return BadRequest("No se puede eliminar una membresía activa.");
                }

                _serviceMembership.DeleteMembership(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}