using AutoMapper;
using Proyecto.BaseDeDatos.Context;
using Proyecto.Dominio.Modelos;
using Proyecto.Dominio.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestuctura.AutoMapper
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 18/09/2024
    /// Descripción: Implementación de un Profile de AutoMapper para crear mapeos de clases.
    /// </summary>
    public class PerfilAutoMapper: Profile
    {
        /// <summary>
        /// Autor: Jirgort McCarty V
        /// Fecha: 18/09/2024
        /// Descripción: Constructor donde se definen los mapeos de clases que manejará AutoMapper.
        /// </summary>
        public PerfilAutoMapper() 
        {
            CreateMap<Usuario, MUsuario>().ReverseMap();
            CreateMap<MArticulo, Articulo>().ReverseMap();

            CreateMap<SAgregarUsuario, MUsuario>().ReverseMap();
           

            CreateMap<SAgregarArticulo, Articulo>().ReverseMap();
            CreateMap<SAgregarArticulo, MArticulo>().ReverseMap();

            CreateMap<SOrden, Orden>().ReverseMap();
            CreateMap<SItem, Item>().ReverseMap();
            CreateMap<MOrden, Orden>().ReverseMap();
            CreateMap<MItem, Item>().ReverseMap();

            CreateMap<Usuario, SAgregarUsuario>()
               .ForMember(dest => dest.Contrasenia, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.Contrasenia)))
               .ReverseMap()
               .ForMember(dest => dest.Contrasenia, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Contrasenia)));
        }
    }
}
