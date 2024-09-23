using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Modelos
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 18/09/2024
    /// Descripcion: Define los atributos de un usuario.
    /// </summary>
    public class MUsuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Contrasenia { get; set; } = string.Empty;
    }
}
