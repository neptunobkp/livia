using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;

public partial class Web_Encuesta_RespuestaParrafo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Pregunta preguntainterna
    {
        set
        {
            if (value == null) return;
            cargarControls(value);
        }
    }


    public void RecogerRespuesta(ItemRespuesta _itemRespuesta)
    {
        _itemRespuesta.GlosaRespuesta = this.tbTextoSimple.Text;
    }

    private void cargarControls(Pregunta value)
    {
        this.tbPregunta.Text = value.GlosaPregunta;
        this.tbAnotacionPregunta.Text = value.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = value.NotaAdicionalFinalPregunta;
    }
}
