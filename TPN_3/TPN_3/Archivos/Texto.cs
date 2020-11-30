using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Informa  el resultado de la operacion GUARDAR DATOS
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">Indicara los DATOS A GUADAR</param>
        /// <returns>TRUE si guardo</returns>FALSE si no guardo
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter stream = new StreamWriter(archivo,false))
                {
                    stream.Write(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Informa si fue posible Retornar la informacion contenida en un archivo
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">Indicara los DATOS A LLER</param>
        /// <returns>TRUE si retorno datos</returns>FALSE si no retornó
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool retorno = false;
            try
            { 
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    retorno = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

           return retorno;
        }
    }
}
