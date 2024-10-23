using Application.Interfaces;
using Application.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomAutenticationService _customAuthenticationService;
        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration config, ICustomAutenticationService autenticationService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _customAuthenticationService = autenticationService;

        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Autenticar(AuthenticationRequest authenticationRequest) //Enviamos como parámetro la clase que creamos arriba
        {
            string token = _customAuthenticationService.Autenticar(authenticationRequest); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            return Ok(token);
        }
    }
}
