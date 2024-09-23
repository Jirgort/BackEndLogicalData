using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces.Servicios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 20/09/2024
    /// Descripción: Interface del servicio JWT.
    /// </summary>
    public interface IServicioJWT
    {
        public string CrearJWT(string nombre);
    }
}
