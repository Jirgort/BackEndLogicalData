using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto.BaseDeDatos.Context;
using Proyecto.Dominio.Interfaces.Repositorios;
using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestuctura.Repositorios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Implementación de la interface del repositorio de articulo.
    /// </summary>
    public class RArticulo : IRepositorioArticulo
    {
        private readonly IMapper _mapper;
        private readonly PruebaLogicalDataContext _pruebaLogicalDataContext;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Constructor.
        /// </summary>
        /// <param name="mapper">Referencia al mapeador de entidades.</param>
        /// <param name="pruebaLogicalDataContext">Contexto de la base de datos.</param> 
        public RArticulo(PruebaLogicalDataContext pruebaLogicalDataContext, IMapper mapper)
        {
            _mapper = mapper;
            _pruebaLogicalDataContext = pruebaLogicalDataContext;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un articulo al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del articulo que se desea agregar.</param>
        /// <returns>El articulo agregado.</returns>
        public async Task<MArticulo> AgregarArticulo(SAgregarArticulo solicitud)
        {
            var articuloNuevo = _mapper.Map<Articulo>(solicitud);
            var articulo = _mapper.Map<MArticulo>(solicitud);

            if (await _pruebaLogicalDataContext.Articulos.AnyAsync(p => p.Codigo == articuloNuevo.Codigo))
            {
                articulo.Codigo = "";
            }
            else
            {
                await _pruebaLogicalDataContext.Articulos.AddAsync(articuloNuevo);
                await _pruebaLogicalDataContext.SaveChangesAsync();

                articulo.Id = articuloNuevo.Id;
                articulo.Codigo = articuloNuevo.Codigo;
            }

            return articulo;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Lista los articulos del sistema.
        /// </summary>
        /// <returns>Lista con los articulos del sistema.</returns>
        public async Task<IEnumerable<MArticulo>> ListarArticulos()
        {
            var articulos = await _pruebaLogicalDataContext.Articulos.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<MArticulo>>(articulos);
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Borra un articulo del sistema.
        /// </summary>
        /// <param name="id">Id del articulo que se desea borrar.</param>
        /// <returns>El articulo borrado.</returns>
        public async Task<MArticulo> BorrarArticulo(int id)
        {
            var articulo = await _pruebaLogicalDataContext.Articulos.FirstOrDefaultAsync(p => p.Id == id);

            if (articulo != null)
            {
                _pruebaLogicalDataContext.Articulos.Remove(articulo);
                await _pruebaLogicalDataContext.SaveChangesAsync();

                return _mapper.Map<MArticulo>(articulo);
            }

            return null;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Actualiza un articulo del sistema.
        /// </summary>
        /// <param name="solicitud">Informacion del articulo para actualizarlo.</param>
        /// <returns>Booleano que inidica si la acción fue exitosa o no.</returns>
        public async Task<bool> ActualizarArticulo(SActualizarArticulo solicitud)
        {
            var articulo = await _pruebaLogicalDataContext.Articulos.FirstOrDefaultAsync(p => p.Id == solicitud.ArticuloId);

            if (articulo != null)
            {
                articulo.Nombre = solicitud.Nombre;
                articulo.Precio = solicitud.Precio;
                articulo.Iva = solicitud.IVA;

                await _pruebaLogicalDataContext.SaveChangesAsync();

                return true;
            }

            return false;

        }

    }

}
