using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
     
    public class Universidad
    {
        #region ENUMERADOS
        public enum EClases
        { 
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region ATRIBUTOS

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Propiedad de lectura escritura, LISTA DE ALUMNOS INSCRIPTOS.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura escritura, LISTA DE QUIENES PUEDEN DAR CLASE.
        /// </summary>
        public List<Profesor> Instructores 
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura escritura, LISTA DE JORNADAS DE LA UNIVERSIDAD.
        /// </summary>
        public List<Jornada> Jornada 
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador. 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (i >= 0 && i < this.Jornada.Count)
                {
                    this.jornada[i] = value;
                }
                
            }
        }

        #endregion

        #region CONSTRUCTOR

        public Universidad()
        {
          this.alumnos=new List<Alumno>();
          this.jornada=new List<Jornada>();
          this.profesores=new List<Profesor>();
        }

    #endregion

    #region METODOS
    /// <summary>
    /// MostrarDatos será privado y de clase. 
    /// </summary>
    /// <param name="uni"></param>
    /// <returns></returns>
    private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA\n");
            foreach (Jornada jornada in uni.Jornada)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("<--------------------------------------------->");
            }
            return sb.ToString();
        }


        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"/Universidad.xml"),uni);
        }

        //public static Universidad Leer()
        //{
        //    Universidad uni;// =  new Universidad();
        //    Xml<Universidad> xml = new Xml<Universidad>();
        //    xml.Leer((AppDomain.CurrentDomain.BaseDirectory + @"/Universidad.xml"), out uni);
        //    return uni;
        //}

        #endregion

        #region METODOS SOBRESCRITOS

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region METODOS SOBRECARGADOS
        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.Alumnos)
            { 
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g==a));
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g==i));
        }

        /// <summary>
        ///La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        ///Sino, lanzará la Excepción SinProfesorException. 
        ///
        /// El distinto retornará el primer Profesor que no pueda dar la clase. 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor =null ;

            //foreach (Jornada claseDictada in u.Jornada)
            //{
            //    if (claseDictada.Clase == clase)
            //    {
                    foreach (Profesor p in u.Instructores)
                    {
                        if (p == clase)
                        {
                            profesor = p;

                            break;
                        }
                    }
            //    }
            //}

            if (profesor is null)
            {
                throw new SinProfesorException();
            }
             return profesor;    
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    profesor = p;
                    break;
                }
            }

            return profesor;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá 
        /// generar y agregar 
        /// Una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia)y
        /// La lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma). 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor;
            profesor = (g == clase);
            jornada = new Jornada(clase,profesor);
            foreach (Alumno alumno in g.alumnos)
            { 
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornada.Add(jornada);
            return g;
        }

        /// <summary>
        /// Se agregarán Alumnos mediante el operador +, validando que no estén previamente cargados. 
        /// Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException. 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>

        public static Universidad operator +(Universidad u, Alumno a)
        {
            Universidad retorno=null;
            if (u == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                u.alumnos.Add(a);
                retorno = u;
            }
            return retorno;
        }

        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente cargados. 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
       
        public static Universidad operator +(Universidad u, Profesor i)
        {
            Universidad retorno = null;
            if (u == i)
            {
                retorno = u;
            }
            else
            {
                u.Instructores.Add(i);
                retorno = u;
            }
            return retorno;
        }
        #endregion
    }
}
