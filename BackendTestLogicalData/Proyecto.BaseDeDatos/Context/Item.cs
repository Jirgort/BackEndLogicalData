using System;
using System.Collections.Generic;

namespace Proyecto.BaseDeDatos.Context
{
    /// <summary>
    /// Almacena los items de las facturas del sistema.
    /// </summary>
    public partial class Item
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Orden Orden { get; set; } = null!;
    }
}
