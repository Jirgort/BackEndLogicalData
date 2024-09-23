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
    /// Descripción: Clase que almacena la forma de solicitud de un item.
    /// </summary>
    public class SItem
    {
        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
