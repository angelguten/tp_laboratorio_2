using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public  class Xml<T>:IArchivo<T>
    {
        /// <summary>
        /// Serializará un objeto en un ARCHIVO XML
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">Indicara el OBJETO A SERIALIZAR</param>
        /// <returns>TRUE , si serializo correctamente</returns>False, se lanza una excepcion
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
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
        /// Deserializa un ARCHIVO XML y retorna su contenido como un objeto.
        /// </summary>
        /// <param name="archivo">Indicara la RUTA DE ACCESO</param>
        /// <param name="datos">devuelve el objeto serializado</param>
        /// <returns>TRUE , si deserializo correctamente</returns>False, se lanza una excepcion
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos=(T)xml.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;


        }
    }
}
