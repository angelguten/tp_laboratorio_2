using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region ENUMERADOS
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region ATRIBUTOS

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region CONSTRUCTOR
        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        #endregion

        #region METODOS
        #endregion

        #region METODOS SOBRESCRITOS
        protected override string MostrarDatos()
        {
            string estadoDeCuenta = this.estadoCuenta.ToString();

            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            //

            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                estadoDeCuenta = "Cuota al dia";
            }
            sb.AppendLine("\nESTADO DE CUENTA :" + estadoDeCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TOMA CLASES DE :" + this.claseQueToma);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region METODOS SOBRECARGADOS
        #endregion

        #region SOBRECARGA DE OPERADORES

        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool retorno = false;
            if ((a.claseQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor))
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            return (a.claseQueToma!=clase);
        }
        #endregion
    }

}

