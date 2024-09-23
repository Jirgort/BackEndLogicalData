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
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción:Implementa los métodos relacionados a la administración de los articulos del sistema.
    /// </summary>
    public class ServicioArticulo: IServicioArticulo
    {
        private readonly ILogger<ServicioArticulo> _logger;
        private readonly IRepositorioArticulo _repositorioArticulo;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="repositorioArticulo">Referencia al repositorio de articulos.</param>
        /// <param name="logger">Referencia a la clase encargada de los Log del sistema</param>
        public ServicioArticulo(
            ILogger<ServicioArticulo> logger, 
            IRepositorioArticulo repositorioArticulo
        ) {
            _logger = logger;
            _repositorioArticulo = repositorioArticulo;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un articulo en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos con los cuales registrar el articulo</param>
        /// <returns>El articulo agregado</returns>
        public async Task<MRespuestaServicio<MArticulo>> AgregarArticulo(SAgregarArticulo solicitud)
        {
            var respuesta = new MRespuestaServicio<MArticulo>();

            try
            {
                var articulo = await _repositorioArticulo.AgregarArticulo(solicitud);
                var arrt = articulo;
                if (articulo.Codigo == "")
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Incorrecto;
                    respuesta.Mensaje = "Ya existe este articulo en el sistema";
                    respuesta.Dato = articulo;
                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                respuesta.Dato = articulo;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error inesperado en el servidor");

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = "Ocurrio un error inesperado en el servidor";
            }

            return respuesta;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Lista los articulos del sistema.
        /// </summary>
        /// <returns>Arreglo con los articulos</returns>
        public async Task<MRespuestaServicio<IEnumerable<MArticulo>>> ListarArticulos()
        {
            var respuesta = new MRespuestaServicio<IEnumerable<MArticulo>>();

            try
            {
                var articulos = await _repositorioArticulo.ListarArticulos();

                if (articulos == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.NoEncontrado;
                    respuesta.Mensaje = "Error al listar los articulos";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                respuesta.Dato = articulos;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error inesperado en el Servidor");

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = "Ocurrio un error inesperado en el Servidor";
            }

            return respuesta;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Borra un articulo en el sistema.
        /// </summary>
        /// <param name="id">Id del articulo por borrar</param>
        /// <returns>El registro borrado</returns>
        public async Task<MRespuestaServicio<MArticulo>> BorrarArticulo(int id)
        {
            var respuesta = new MRespuestaServicio<MArticulo>();

            try
            {
                var articulo = await _repositorioArticulo.BorrarArticulo(id);

                if (articulo == null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.NoEncontrado;
                    respuesta.Mensaje = "El Articulo que desea borrar no se encuentra.";

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                respuesta.Dato = articulo;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error inesperado en el Servidor");

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = "Ocurrio un error inesperado en el Servidor";
            }

            return respuesta;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Actualiza un articulo del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del articulo para actualizarlo.</param>
        /// <returns>Booleano que indica si la acción fue exitosa o no.</returns>
        public async Task<MRespuestaServicio<bool>> ActualizarArticulo(SActualizarArticulo solicitud)
        {
            var respuesta = new MRespuestaServicio<bool>();

            try
            {
                var articuloActualizado = await _repositorioArticulo.ActualizarArticulo(solicitud);

                if (!articuloActualizado)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.NoEncontrado;
                    respuesta.Mensaje = "El Articulo que desea editar no se encuentra.";
                    respuesta.Dato = false;

                    return respuesta;
                }

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                respuesta.Dato = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error inesperado en el Servidor");

                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = "Ocurrio un error inesperado en el Servidor";
            }

            return respuesta;

        }


    }
}
