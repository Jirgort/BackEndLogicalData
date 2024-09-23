using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Solicitudes
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 20/09/2024
    /// Descripción: Clase que almacena la forma de solicitud de una orden.
    /// </summary>
    public class SOrden
    {
        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}
