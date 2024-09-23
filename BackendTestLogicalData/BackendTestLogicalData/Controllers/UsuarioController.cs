using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto.Dominio.Enumerados;
using Proyecto.Dominio.Interfaces.Servicios;
using Proyecto.Dominio.Solicitudes;


namespace BackendTestLogicalData.Controllers
{
    /// <summary>
    /// Autor: Jirgort McCarty
    /// Fecha: 18/09/2024
    /// Descripción: Controlador encargado de la administración de los usuarios del sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IServicioUsuario _servicioUsuario;
        private readonly IConfiguration _configuration;
        public UsuarioController(IServicioUsuario servicioUsuario, IConfiguration configuration)
        {
            _servicioUsuario = servicioUsuario;
            _configuration = configuration;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 18/09/2024
        /// Descripción: Agrega un usuario en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        [HttpPost]
        [Route("RegistrarUsuario")]
        public async Task<IActionResult> AgregarUsuario([FromBody] SAgregarUsuario solicitud)
        {
            var response = await _servicioUsuario.AgregarUsuario(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {

                return Ok(response);
            }

            return BadRequest(response);
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 18/09/2024
        /// Descripción: Autentica un usuario en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos del usuario que se desea autenticar.</param>
        /// <returns>El usuario agregado.</returns>

        [HttpPost]
        [Route("AutenticarUsuario")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] SIniciarSesion solicitud)
        {

            var response = await _servicioUsuario.AutenticarUsuario(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {

                return Ok(response);
            }

            return Unauthorized(response);
        }



    }
}
