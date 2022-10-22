using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Pulse.Contactador.Dto
{
    [Serializable]
    [Description("Periodo Ejecucion")]
    public enum TiposPeriodosEjecucion
    {
        Indefinido = 1,
        [Description("Solo una vez")]
        SoloUnaVez = 2,
        [Description("Una vez por semana")]
        UnaVezPorSemana = 3,
        [Description("Una vez por mes")]
        UnaVezPorMes = 4,
        [Description("Todos los dias")]
        Todoslosdias = 5,
    }

    [Serializable]
    [Description("Tipo de envio masivo")]
    public enum TiposEnvioMasivo
    {
        [Description("Mensaje único")]
        MensajeUnico = 1,
        [Description("Mensaje personalizado")]
        MensajePersonalizado = 2,
    }

}
