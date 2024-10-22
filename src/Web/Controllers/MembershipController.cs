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
    public class MembershipController : ControllerBase
    {
       private readonly IMembershipService _serviceMembership;
        public MembershipController(IMembershipService service)
        {
            _serviceMembership = service;
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
    
     [HttpDelete("Delete/{id}")]
        public ActionResult DeleteMembership(int id)
        {
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
    }
}
