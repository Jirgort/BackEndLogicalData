using System;
using System.Collections.Generic;

namespace Proyecto.BaseDeDatos.Context
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public bool Iva { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
