using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces.Repositorios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Interface del repositorio de usuario.
    /// </summary>
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud);

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>El usuario autenticado.</returns>
        public Task<MUsuario> AutenticarUsuario(SIniciarSesion solicitud);
    }
}
