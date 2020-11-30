

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {

        #region ATRIBUTOS

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set 
            { 
                this.instructor = value; 
            }
        }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Se inicializará la lista de alumnos en el constructor por defecto. 
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Guarda los datos contenidos en el objeto jornada en el archivo Jornada.txt
        /// </summary>Si la operacion GUARDAR, fue exitosa retorna 
        /// <returns>TRUE</returns>caso contrario False
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;

            Texto archivoDeTexto = new Texto();
            retorno= archivoDeTexto.Guardar((AppDomain.CurrentDomain.BaseDirectory+@"/Jornadas.txt"), jornada.ToString());

            return retorno;
        }
        /// <summary>
        /// Lee los datos contenidos en el archivo Jornada.txt
        /// </summary>Si la operacion LLER, fue exitosa retorna los DATOS A LEER
        /// <returns></returns>
        public static string Leer()
        {
            string retorno = "";
            bool pudoLeer = false;
            string datosParaLeer = "";

            Texto archivoDeTexto = new Texto();
            if( pudoLeer = archivoDeTexto.Leer((AppDomain.CurrentDomain.BaseDirectory + @"/Jornadas.txt"), out datosParaLeer))
            {
                retorno = datosParaLeer;
            }

            return datosParaLeer;
        }

        #endregion

        #region METODOS SOBREESCRITOS

        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE: "+this.clase+" POR "+this.Instructor);
            //sb.AppendLine();
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase. 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.alumnos)
            { 
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            
            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j==a));
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }


            #endregion
    }
}
