using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Dominio.Enumerados
{
    /// <summary>
    /// Autor: Jirgort McCarty V
    /// Fecha: 19/09/2024
    /// Descripción: Define los posibles estados de la respuesta.
    /// </summary>
    public enum EEstadoRespuestaServicio
    {
        Exitoso = 1,
        NoEncontrado = 2,
        Incorrecto = 3,
        Error = 4
    }
}
