using Proyecto.Dominio.Modelos;
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
    /// Descripción: Clase que almacena la forma de solicitud de agregar una orden.
    /// </summary>
    public class SAgregarOrden
    {
        public SOrden? Orden { get; set; }

        public ICollection<SItem>? Items { get; set; }
    }
}
