using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _serviceMembership;
        public MembershipController(IMembershipService service)
        {
            _serviceMembership = service;
        }

        /*[HttpPost("AddMembeship")]
        public ActionResult<Membership> AsignarMembership([FromBody] Membership membership)
        {
            // Asignar membresia al cliente ||| VER TEMA ROLES

            // Al momento asignar, determinar de que tipo es mediante enum::  SubscriptionType

            // ver si es cliente o cual rol

        }
    
        [HttpGet("{id}")]
        public ActionResult<Membership> GetMembershipByID(int id) 
        {

            // devolver, el nombre del cliente | estadod de la membresia 
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
            //quitarle la membresia 
            //VER TEMA DE PAYMENT , SI ESTA ACTIVA O NO!!!
            try
            {
                _serviceMembership.DeleteMembership(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        */

    }
}
