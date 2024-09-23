using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Modelos
{
    /// <summary>
    /// Autor: Jirgort McCarty
    /// Fecha: 20/09/2024
    /// Descripcion: Modelo que define los atributos de un item.
    /// </summary>
    public class MItem
    {
        public int Id { get; set; }

        public int OrdenId { get; set; }

        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }
    }
}
