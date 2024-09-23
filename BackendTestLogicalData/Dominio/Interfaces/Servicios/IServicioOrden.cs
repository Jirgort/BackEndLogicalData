using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
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
    /// Descripción: Interface del servicio de ordenes.
    /// </summary>
    public interface IServicioOrden
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 20/09/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma de la orden y sus items que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public Task<MRespuestaServicio<MOrden>> AgregarOrden(SAgregarOrden solicitud);

    }
}

