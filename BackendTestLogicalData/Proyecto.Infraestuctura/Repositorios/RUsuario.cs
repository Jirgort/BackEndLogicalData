using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto.BaseDeDatos.Context;
using Proyecto.Dominio.Interfaces.Repositorios;
using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestuctura.Repositorios
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Implementación de la interface del repositorio de usuario.
    /// </summary>
    /// 
    public class RUsuario : IRepositorioUsuario
    {
        private readonly IMapper _mapper;

        private readonly PruebaLogicalDataContext _dbContext;

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Constructor.
        /// </summary>
        /// <param name="mapper">Referencia al mapeador de entidades.</param>
        /// <param name="dbContex">Contexto de la base de datos.</param> 
        public RUsuario(PruebaLogicalDataContext dbContex, IMapper mapper)
        {
            _dbContext = dbContex;
            _mapper = mapper;
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Agrega un usuario al sistema.
        /// </summary>
        /// <param name="solicitud">Solicitud con la forma del usuario que se desea agregar.</param>
        /// <returns>El usuario agregado.</returns>
        public async Task<MUsuario> AgregarUsuario(SAgregarUsuario solicitud)
        {
            var usuarioExiste = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Username == solicitud.Username);
            if (usuarioExiste == null)
            {
                var nuevoUsuario = _mapper.Map<Usuario>(solicitud);
                nuevoUsuario.Contrasenia = HashearContrasenia(solicitud.Contrasenia);
                var usuario = _mapper.Map<MUsuario>(solicitud);

                await _dbContext.Usuarios.AddAsync(nuevoUsuario);
                await _dbContext.SaveChangesAsync();

                usuario.Id = nuevoUsuario.Id;

                return usuario;
            }
            return null;
        }

        private byte[] HashearContrasenia(string contra)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contra));
            }
        }

        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 19/09/2024
        /// Descripción: Autentica un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con las credenciales del usuario.</param>
        /// <returns>El usuario autenticado.</returns>
        public async Task<MUsuario> AutenticarUsuario(SIniciarSesion solicitud)
        {
            var hashedC = HashearContrasenia(solicitud.Contrasenia);
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Username == solicitud.Username && u.Contrasenia == hashedC);

            return _mapper.Map<MUsuario>(usuario);
        }
    }

}
