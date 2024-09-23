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
    /// Descripcion: Modelo que define los atributos del JWT.
    /// </summary>
    public class MJwt
    {
        public string Key { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;

    }
}
