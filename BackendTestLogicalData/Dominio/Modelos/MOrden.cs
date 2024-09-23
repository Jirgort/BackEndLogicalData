using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Modelos
{
    /// <summary>
    /// Autor: Jirgort McCArty V
    /// Fecha: 20/09/2024
    /// Descripcion: Modelo que define los atributos de una orden.
    /// </summary>
    public class MOrden
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public ICollection<MItem> Items { get; set; } = new List<MItem>();
    }
}
