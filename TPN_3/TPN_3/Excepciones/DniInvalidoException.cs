using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string mensaje;

        public DniInvalidoException():this("FORMATO DE DNI INVALIDO")
        { 
        }
        public DniInvalidoException(Exception e): base("FORMATO DE DNI INVALIDO", e)//public DniInvalidoException(Exception e)
        {
        }
        public DniInvalidoException(string message):base(message)
        {
            this.mensaje = message;
        }
        public DniInvalidoException(string message,Exception e):base(message,e)//:base("FORMATO DE DNI INVALIDO",e)
        {
            this.mensaje = message;
        }
    }
}
