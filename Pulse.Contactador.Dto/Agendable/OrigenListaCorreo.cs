using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class OrigenListaCorreo
    {
        public TipoOrigenListaCorreo TipoOrigenListaCorreo { get; set; }
        public String PathArchivoListaCorreos { get; set; }
        public String SentenciaSql { get; set; }
        public String UrlServicioWeb { get; set; }
        public String NombreServicioWeb { get; set; }
        public String MetodoServicioWeb { get; set; }
        public CadenaConexion CadenaConexion { get; set; }
        public object[] ParametrosServicioWeb { get; set; }
        public bool CargarEnDemanda { get; set; }
        public bool RutCargadoConDigitoVerificador { get; set; }
    }

}
