using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    public enum TipoOrigenListaCorreo
    {
        Indefinido,
        SentenciaSql,
        ArchivoCargaCsv,
        Manual,
    }
}
