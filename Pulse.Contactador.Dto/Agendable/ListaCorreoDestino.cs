using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public class ListaCorreoDestino : LayerSupertype
    {
        public List<CorreoDestino> CorreosDestino { get; set; }
        public String Descripcion { get; set; }
        public OrigenListaCorreo Origen { get; set; }
        public String Codigo { get; set; }
        public TiposFormaContacto TipoFormaContacto { get; set; }


        public GrupoEncuestado GrupoEncuestado { get; set; }
    }
}
