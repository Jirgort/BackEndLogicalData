using Microsoft.Extensions.Logging;
using Proyecto.Dominio.Enumerados;
using Proyecto.Dominio.Interfaces.Repositorios;
using Proyecto.Dominio.Interfaces.Servicios;
using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestuctura.Servicios
{
    public class ServicioOrden : IServicioOrden
    {
        private readonly ILogger<ServicioOrden> _logger;

        private readonly IRepositorioOrden _repositorioOrden;

        /// <summary>
        /// Autor: Jirgort McCarty
        /// Fecha: 20/09/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="logger">Referencia a la clase encargada de los Logs del sistema.</param>
        /// <param name="repositorioOrden"> Referencia al repositorio de ordenes. </param>
        public ServicioOrden(ILogger<ServicioOrden> logger, IRepositorioOrden repositorioOrden)
        {
            _logger = logger;
            _repositorioOrden = repositorioOrden;
        }

        /// <summary>
        /// Autor: Jirgort McCarty
        /// Fecha: 20/09/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma de la orden y sus items que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public async Task<MRespuestaServicio<MOrden>> AgregarOrden(SAgregarOrden solicitud)
        {
            var respuesta = new MRespuestaServicio<MOrden>();

            try
            {
                var orden = await _repositorioOrden.AgregarOrden(solicitud);

                if (orden == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Incorrecto;
                    respuesta.Mensaje = "Error al intentar agregar la orden";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                respuesta.Dato = orden;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocuurio un error en el servidor");

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = ex.InnerException.Message;
            }

            return respuesta;
        }

        
    }
}

