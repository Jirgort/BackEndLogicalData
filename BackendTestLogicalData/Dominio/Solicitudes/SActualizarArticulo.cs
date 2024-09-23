using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Solicitudes
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Clase que almacena la forma de solicitud de actualizar un articulo.
    /// </summary>
    public class SActualizarArticulo
    {
        public int ArticuloId { get; set; }
        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public bool IVA { get; set; }
    }
}
