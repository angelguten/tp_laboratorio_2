using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Numero
    {
        #region ATRIBUTOS

        private double _numero;

        #endregion 

        #region PROPIEDADES
        public string setNumero
        {
            //La propiedad SetNumero asignará un valor al atributo numero, previa validación.
            //En este lugar será el único en todo el código que llame al método ValidarNumero

            set
            {
                
                this._numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region CONSTRUCTORES
        public Numero()
        {
            this._numero = 0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string strNumero)
        {
           this.setNumero = strNumero;//asigna el stringNumero a la propiedad setNumero
        }
        #endregion

        #region METODOS
        /// <summary>
        /// El método privado EsBinario validará que la cadena de caracteres esté compuesta 
        /// SOLAMENTE por caracteres '0' o '1'. 
        /// </summary>
        /// <param name="Binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for (int i = 0; i < binario.Length; i++)
            {
                string digito = "";
                digito = binario[i].ToString();
                if ((digito != "0") && (digito != "1"))
                {
                    return false;
                }
            }
            return retorno;
        }
        public string BinarioDecimal(string binario)
        {
           
            if (!(this.EsBinario(binario)))
            {
                return  "Valor invalido";
            }


          
            double acum = 0;
            double numero = 0;
            double potencia = 0;
            potencia = binario.Length;

            for (int i = 0; i < binario.Length; i++)
            {
                string digito = "";
                potencia = (potencia - 1);

                digito = binario[i].ToString();
                if (double.TryParse(digito, out numero))
                {
                    acum = acum + numero * (Math.Pow(2, potencia));
                }
            }
            return acum.ToString();
        }

        public string DecimalBinario(double numero)
        {
            string cadena = "";


            int cociente = 0;
            int resto = 0;

            do
            {
                cociente = (int)numero / 2;
                resto = (int)numero % 2;

                numero = cociente;

                cadena = resto + cadena;

            }
            while (cociente != 0);

            return cadena;
        }
    
        public string DecimalBinario(string binario)
        {
        string cadena = "Valor invalido ";

        double numeroValidado = 0;
        if (double.TryParse(binario, out numeroValidado))
        {
            cadena = this.DecimalBinario(numeroValidado);

            return cadena;
        }


        return cadena;
    }

        private double ValidarNumero(string strNumero)
        {// ValidarNumero comprobará que el valor recibido sea numérico, y lo retornará en      
         // double. Caso contrario, retornará 0.
            
            double numeroValidado = 0;
            if(double.TryParse(strNumero,out numeroValidado))
            {
                return numeroValidado;
            }
            return numeroValidado;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        //Los operadores realizarán las operaciones correspondientes entre dos números.
        public static double operator +(Numero n1,Numero n2)
        {
            double resultado = 0;
            resultado = n1._numero + n2._numero;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = 0;
            resultado = n1._numero - n2._numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;
            resultado = n1._numero * n2._numero;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {

            double resultado = 0;
            if (n2._numero == 0)
            {
                return double.MinValue;//resultado;
            }
            else 
                { 
                resultado = n1._numero / n2._numero;
                return resultado;
                } 
        }
        #endregion
    }
}
