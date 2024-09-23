using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Solicitudes
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripcion: Modelo que almacena la forma de solicitud de inicio de sesión.
    /// </summary>
    public class SIniciarSesion
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Contrasenia { get; set; } = string.Empty;

    }
}
