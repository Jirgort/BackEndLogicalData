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
    /// Fecha: 19/09/2024
    /// Descripción: Controlador encargado de gestionar los articulos en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticuloController : Controller
    {
        private readonly IServicioArticulo _servicioArticulo;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="servicioArticulo">Servicio encargado de la administración de los articulos</param>
        public ArticuloController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un articulo en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos con los cuales registrar el articulo</param>
        /// <returns>El articulo agregado</returns>
        [HttpPost]
        [Route("AgregarArticulo")]
        public async Task<IActionResult> AgregarArticulo([FromBody] SAgregarArticulo solicitud)
        {
            var response = await _servicioArticulo.AgregarArticulo(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Lista los articulos del sistema.
        /// </summary>
        /// <returns>Arreglo con los articulos</returns>
        [HttpGet]
        [Route("ListarArticulos")]
        public async Task<IActionResult> ListarArticulos()
        {
            var response = await _servicioArticulo.ListarArticulos();

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Borra un articulo en el sistema.
        /// </summary>
        /// <param name="id">Id del articulo por borrar</param>
        /// <returns>El registro borrado</returns>
        [HttpDelete]
        [Route("BorrarArticulo")]
        public async Task<IActionResult> BorrarArticulo([FromQuery] int id)
        {
            var response = await _servicioArticulo.BorrarArticulo(id);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Actualiza un articulo en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos con los cuales actualizar el articulo</param>
        /// <returns>Un booleano indicando el éxito de la solicitud</returns>
        [HttpPut]
        [Route("ActualizarArticulo")]
        public async Task<IActionResult> ActualizarArticulo([FromBody] SActualizarArticulo solicitud)
        {
            var response = await _servicioArticulo.ActualizarArticulo(solicitud);

            if (response.EstadoRespuesta.Equals(EEstadoRespuestaServicio.Exitoso))
            {
                return Ok(response);
            }

            return NotFound(response);
        }

    }
}
