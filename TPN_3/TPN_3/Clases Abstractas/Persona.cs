using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ENUMERADOS
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region ATRIBUTOS
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad Lectura/Escritura, valida APELLIDO
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }

        }
        /// <summary>
        /// Propiedad Lectura/Escritura, valida DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad Lectura/Escritura, valida NACIONALIDAD
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad Lectura/Escritura, valida NOMBRE
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad Lectura/Escritura con validacion
        /// </summary>
        public string StringToDNI
         {
            set
            {
                this.dni = ValidarDni(nacionalidad, value);
            }
        }

        #endregion

        #region CONSTRUCTORES

        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        { 
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string stringDni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {   
            this.StringToDNI =stringDni;     
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad.
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999.
        /// 
        /// Caso contrario,
        /// se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        /// 
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if ((dato >= 1) && (dato <= 98999999))
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if ((dato >= 90000000) && (dato <= 99999999))
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
               default:
                        throw new NacionalidadInvalidaException();
                    //break;
            }
            return dniValidado;
        }

        /// <summary>
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.)
        /// se lanzará DniInvalidoException. 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniValidado =0;

            if ((int.TryParse(dato, out dniValidado)) && ((dato.Length > 0) && (dato.Length <= 8)))
            {
                dniValidado = ValidarDni(nacionalidad, dniValidado);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return dniValidado;
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará
        /// </summary>
        private string ValidarNombreApellido(string dato)
        {
            string nombreValidado = "";

            string cadena = @"^{A-Z,a-z}+$";

            if (Regex.IsMatch(dato, cadena))
            {
                nombreValidado = dato;
            }
            else
            {
                nombreValidado= "";
            }
            return nombreValidado;
        }

        #endregion

        #region SOBREESCRITURA DE METODOS

        /// <summary>
        /// ToString retornará los datos de la Persona. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO :" + this.Apellido + ", " + this.Nombre);// + "NACIONALIDAD :" + this.nacionalidad);
            sb.AppendLine("NACIONALIDAD :" + this.nacionalidad);

            return sb.ToString();
        }

        #endregion
    }
}
