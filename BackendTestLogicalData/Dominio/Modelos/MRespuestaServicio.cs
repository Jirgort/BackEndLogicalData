using Proyecto.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Modelos
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 18/09/2024
    /// Descripción: Modelo que define los datos de una respuesta de un servicio.
    /// </summary>
    /// <typeparam name="T">El tipo de dato específico retornado por cada método de un servicio</typeparam>
    public class MRespuestaServicio<T>
    { 
        public EEstadoRespuestaServicio EstadoRespuesta {  get; set; }

        public string Mensaje { get; set; } = string.Empty;

        public T? Dato { get; set; }
    }
}
