using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        #region ATRIBUTOS

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region CONSTRUCTOR

        static Profesor()
        { 
            random = new Random();
        }
        public Profesor()
        {
            
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia= new Queue <Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region METODOS

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }


        #endregion

        #region METODOS SOBREESCRITOS

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor. 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
           
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da. 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            //string cadena = "CLASES DEL DIA :\n";
            sb.AppendLine("CLASES DEL DIA :");

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();//cadena + 
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase. 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases claseQueDa in i.clasesDelDia)
            { 
                if (claseQueDa==clase)
                {
                    retorno = true;
                    break;
                }
            }
            
            return retorno;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i==clase));
        }
        #endregion
    }
}
