using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region ATRIBUTOS

        private int legajo;

        #endregion

        #region CONSTRUCTORES
        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Método protegido y virtual MostrarDatos retornará todos los datos del Universitario. 
        /// </summary>
        /// <returns></returns>
        /// 
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("\nLEGAJO :" + this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Método protegido y abstracto ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales. 
        /// para establecer la igualdad
        /// Verifica si esta instancia y un objeto obj son del mismo tipo
        /// si lo son, compara la instancia actual y obj, reutilizando el operador == para determinar si legajo y DNI son iguales
        /// </summary>
        /// <param name="obj"></param>objeto a comparar
        /// <returns>retorna TRUE en caso que esta instancia y obj sean iguales, caso contrario FALSE</returns>

        #region SOBREESCRITURA DE METODOS


        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this.GetType()==obj.GetType())
                {
                    if (this==(Universitario)obj)
                    {
                        retorno = true;
                    }   
                }
            }
            return retorno;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            bool retorno = false;

            if ((pg1.legajo==pg2.legajo)|| (pg1.DNI==pg2.DNI))
            {
                retorno = true;
            }

            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1==pg2));
        }

        #endregion
    }
}
