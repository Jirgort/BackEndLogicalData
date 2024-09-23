using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces.Repositorios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 20/09/2024
    /// Descripción: Interface del repositorio de ordenes.
    /// </summary>
    public interface IRepositorioOrden
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 20/09/2024
        /// Descripción: Agrega una orden al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con forma de la orden que se desea agregar.</param>
        /// <returns>La orden agregada.</returns>
        public Task<MOrden> AgregarOrden(SAgregarOrden solicitud);

    }
}
