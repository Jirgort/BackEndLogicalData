using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioArticulo
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un articulo al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del articulo que se desea agregar.</param>
        /// <returns>El articulo agregado.</returns>
        public Task<MArticulo> AgregarArticulo(SAgregarArticulo solicitud);

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Lista los articulos del sistema.
        /// </summary>
        /// <returns>Lista con los articulos del sistema.</returns>
        public Task<IEnumerable<MArticulo>> ListarArticulos();

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Borra un articulo del sistema.
        /// </summary>
        /// <param name="id">Id del articulo que se desea borrar.</param>
        /// <returns>El articulo borrado.</returns>
        public Task<MArticulo> BorrarArticulo(int id);

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Actualiza un articulo del sistema.
        /// </summary>
        /// <param name="solicitud">Datos del articulo para actualizarlo.</param>
        /// <returns>Booleano que inidica si la acción fue exitosa o no.</returns>
        public Task<bool> ActualizarArticulo(SActualizarArticulo solicitud);


    }
}
