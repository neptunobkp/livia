using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ArchivoEnviable
    {
        public String RutaFisica { get; set; }
        public String Nombre { get; set; }
        public int Peso { get; set; }
    }
}
