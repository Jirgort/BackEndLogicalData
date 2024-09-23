using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Solicitudes
{
    /// <summary>
    /// Autor: Jirgort McCarty
    /// Fecha: 18/09/2024
    /// Descripción: Define los datos necesarios para la solicitud de agregar un usuario.
    /// </summary>
    public class SAgregarUsuario
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;
    }
}
