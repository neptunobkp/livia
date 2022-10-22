using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils.Exceptions
{
    public class ActionableException : ApplicationException
    {
        /// <summary>
        /// Crea una nueva ActionableException.
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception</param>
        public ActionableException(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Crea una nueva ActionableException.
        /// </summary>
        /// <param name="mensaje">El mensaje de la exception, debe describir como solucionar el problema</param>
        /// <param name="interna">Una exception para agragar como innerException</param>
        public ActionableException(string mensaje, Exception interna)
            : base(mensaje, interna)
        {
        }

        /// <summary>
        /// Crea una nueva ActionableException.
        /// </summary>
        /// <param name="source">La fuente que produce el problema, se debe describir que produjo la exception</param>
        /// <param name="mensaje">El mensaje de la exception, debe describir como solucionar el problema</param>
        /// <param name="interna">Una exception para agragar como innerException</param>
        public ActionableException(string source, string mensaje, Exception interna)
            : base(mensaje, interna)
        {
            this.Source = source;
        }
    }
}
