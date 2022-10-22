using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Contactador.Dto
{

    /// <summary>
    /// ¡IMPORTANTE! De cambiarse el nombre de alguno de estos valores, se debera cambiar de forma manual en el control paginaEncuesta dentro de Encuestas/PanelControl
    /// </summary>
    public enum TiposPregunta
    {
        Indefinida,
        SeleccionUnica, //propia clase
        SeleccionMultiple, //propia clase
        TextoSimple, //pregunta
        TextoEnsayo, //pregunta
        Matriz, //propia clase
    }
}
