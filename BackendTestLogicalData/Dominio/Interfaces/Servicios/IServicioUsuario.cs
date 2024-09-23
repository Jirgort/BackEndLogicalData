using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Define los métodos relacionados a la administración de los usuarios del sistema.
    /// </summary>
    public interface IServicioUsuario
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar</param>
        /// <returns>El usuario agregado.</returns>
        public Task<MRespuestaServicio<MUsuario>> AgregarUsuario(SAgregarUsuario solicitud);

        public Task<MRespuestaServicio<MAutenticacion>> AutenticarUsuario(SIniciarSesion solicitud);
    }
}
