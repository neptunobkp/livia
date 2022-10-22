using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemonioContactador
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WSExecutorContactador.EjecutarTareas serviceContext = new DemonioContactador.WSExecutorContactador.EjecutarTareas();
                //String resultado = serviceContext.EjecutarTareasPendientes();
            }
            catch (Exception)
            {
            }
        }
    }
}
