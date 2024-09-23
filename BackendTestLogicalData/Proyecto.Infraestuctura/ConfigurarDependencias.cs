using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.BaseDeDatos.Context;
using Proyecto.Dominio.Interfaces.Repositorios;
using Proyecto.Dominio.Interfaces.Servicios;
using Proyecto.Infraestuctura.AutoMapper;
using Proyecto.Infraestuctura.Repositorios;
using Proyecto.Infraestuctura.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestuctura
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 18/09/2024
    /// Descripción: Agrupa los métodos para configurar las dependencias del proyecto.
    /// </summary>
    public static class ConfigurarDependencias
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 18/09/2024
        /// Descripción: Inicia la sesión de un usuario en el sistema.
        /// </summary>
        /// <param name="services">Referencia a la colección de servicios usada en el proyecto</param>
        /// <param name="configuration">Referencia a la configuración usada en el proyecto</param>
        /// <returns>La colección de servicios con las implementaciones ya configuradas</returns>
        public static IServiceCollection ConfigurarProyecto(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {

            services.AddScoped<IServicioJWT, ServicioJWT>();
            services.AddDbContext<PruebaLogicalDataContext>(optionsLifetime: ServiceLifetime.Transient);
            services.AddAutoMapper(typeof(PerfilAutoMapper));
            services.AddScoped<IServicioArticulo, ServicioArticulo>();
            services.AddScoped<IRepositorioArticulo, RArticulo>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IRepositorioUsuario, RUsuario>();
            services.AddScoped<IServicioOrden, ServicioOrden>();
            services.AddScoped<IRepositorioOrden, RepositorioOrden>();
            return services;
        }
    }
}
