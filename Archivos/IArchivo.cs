using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Informa  el resultado de la operacion GUARDAR DATOS
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">Indicara los DATOS A GUADAR</param>
        /// <returns>TRUE si guardo</returns>FALSE si no guardo
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Informa si fue posible Retornar la informacion contenida en un archivo
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">Indicara los DATOS A LLER</param>
        /// <returns>TRUE si retorno datos</returns>FALSE si no retornó
        bool Leer(string archivo, out T datos);
    }
}
