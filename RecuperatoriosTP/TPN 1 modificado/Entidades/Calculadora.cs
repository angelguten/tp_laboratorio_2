using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Entidades
{
    public class Calculadora
    {
        #region ATRIBUTOS
        #endregion

        #region PROPIEDADES
        #endregion

        #region CONSTRUCTORES
        
        #endregion

        #region METODOS
        /// <summary>
        /// Llama al metodo ValidarOperador, y despues de validar el operador
        /// realiza la operacion pedida entre ambos, si se trata de una division por CERO
        /// retornara double.MinValue
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado = 0;
            string operadorValidado = ValidarOperador(operador);

            switch(operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                break;
                case "-":
                resultado = num1 - num2;
                break;
                case "*":
                       resultado  =  num1 * num2;
                break;
                case "/":
                    if ((num2.Equals(0)))
                    {
                        resultado = double.MinValue;
                    }
                    if (!(num2.Equals(0)))
                    {
                        resultado = num1 / num2;
                    }
                break;
            
            }
            return resultado;
        }
        /// <summary>
        /// recibe un parametro string, y evalua que que el operador introducido 
        /// corresponda a una operacion permitida, luego retorna el operador validado
        /// o en caso contrario un operador"+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {                                               
            string cadena="+";
            if ((operador == "+") || (operador == "-") || (operador == "*") || (operador == "/"))
            {
                return operador;
            }
            else
            {
                return cadena;
            }
           
        }
        #endregion
    }
}
