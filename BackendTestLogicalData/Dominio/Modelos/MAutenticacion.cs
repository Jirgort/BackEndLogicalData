using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Modelos
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripcion: Modelo que define los atributos de un articulo.
    /// </summary>
    public class MAutenticacion
    {
        public string Token { get; set; } = string.Empty;
        public MUsuario? Usuario { get; set; }
    }
}
