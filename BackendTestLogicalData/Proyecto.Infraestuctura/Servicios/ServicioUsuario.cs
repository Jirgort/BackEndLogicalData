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
    /// Fecha: 18/09/2024
    /// Descripción:Implementa los métodos relacionados a la administración de los usuarios del sistema.
    /// </summary>
    public class ServicioUsuario: IServicioUsuario
    {
        private readonly ILogger<ServicioUsuario> _logger;
        private readonly IRepositorioUsuario _rUsuario;
        private readonly IServicioJWT _servicioJWT;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Constructor de la clase.
        /// </summary>
        /// <param name="repositorioUsuario">Referencia al repositorio de usuarios.</param>
        /// <param name="logger">Referencia a la clase encargada de los Log del sistema</param>
        public ServicioUsuario(ILogger<ServicioUsuario> logger, IRepositorioUsuario repositorioUsuario, IServicioJWT servicioJWT)
        {
            _logger = logger;
            _rUsuario = repositorioUsuario;
            _servicioJWT = servicioJWT;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un usuario en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos con los cuales registrar el usuario</param>
        /// <returns>El usuario agregado</returns>
        public async Task<MRespuestaServicio<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud)
        {
            var respuesta = new MRespuestaServicio<MUsuario>();

            try
            {
                var usuario = await _rUsuario.AgregarUsuario(solicitud);

                if (usuario != null)
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                    respuesta.Dato = usuario;
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Incorrecto;
                    respuesta.Mensaje = "Credenciales incorrectas";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _logger.LogError(ex, "Ocurrio un error inesperado al intentar agregar el usuario ");
                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = ex.ToString();
            }

            return respuesta;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción:Autentica un usuario en el sistema.
        /// </summary>
        /// <param name="solicitud">Los datos con los cuales autenticar el usuario</param>
        /// <returns>El usuario autenticado</returns>
        public async Task<MRespuestaServicio<MAutenticacion>> AutenticarUsuario(SIniciarSesion solicitud)
        {
            var respuesta = new MRespuestaServicio<MAutenticacion>();

            try
            {
                var usuarioAutenticado = await _rUsuario.AutenticarUsuario(solicitud);

                if (usuarioAutenticado != null)
                {
                    var token = _servicioJWT.CrearJWT(solicitud.Username);
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Exitoso;
                    respuesta.Dato = new MAutenticacion { Token = token, Usuario = usuarioAutenticado };
                }
                else
                {
                    respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Incorrecto;
                    respuesta.Mensaje = "El nombre de ususario o contraseña son incorrectos";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un error intentando autenticar al usuario");
                respuesta.EstadoRespuesta = EEstadoRespuestaServicio.Error;
                respuesta.Mensaje = "Ocurrio un error intentando autenticar al usuario";
            }

            return respuesta;
        }




    }
}
