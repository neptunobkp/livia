using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto.Agendable
{

    public enum TiposEstadoEnvio
    {
        Indefinido,
        Enviado,
        Postergado,
        Fallido,
        Pendiente,
        Rebotado,
        Abierto,
        Interactuado,
    }
}
