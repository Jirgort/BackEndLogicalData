using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Dominio.Enumerados;
using Proyecto.Dominio.Interfaces.Servicios;
using Proyecto.Dominio.Solicitudes;

namespace API.Controllers
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 20/09/2024
    /// Descripción: Controlador encargado de gestionar las ordenes en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdenController : Controller
    {
        private readonly IServicioOrden _servicioOrden;
        private readonly IServicioJWT _serviciojwt;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 20/09/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="servicioOrden">Servicio de ordenes.</param>
        public OrdenController(IServicioOrden servicioOrden, IServicioJWT servicioJwt)
        {
            _servicioOrden = servicioOrden;
            _serviciojwt = servicioJwt;
        }

        /// <summary>
        /// Autor: Jirgot McCarty V
        /// Fecha:  20/09/2024
        /// Descripción: Agregar una orden.
        /// </summary>
        /// <param name="solicitud">Los datos de la orden a agregar.</param>
        /// <returns>El objeto orden agregado.</returns>
        [HttpPost]
        [Route("AgregarOrden")]
        public async Task<IActionResult> AgregarOrden([FromBody] SAgregarOrden solicitud)
        {
            var response = await _servicioOrden.AgregarOrden(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {

                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
