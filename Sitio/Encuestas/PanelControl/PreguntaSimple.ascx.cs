using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;

public partial class Encuestas_PanelControl_PreguntaSimple : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Pregunta PreguntaInterna
    {
        get
        {
            return recogerInformacion();
        }
        set
        {
            presentarInformacion(value);
        }
    }

    private void presentarInformacion(Pregunta preguntaTextoSimple)
    {
        if (preguntaTextoSimple == null) return;
        ViewState[preguntaTextoSimple.Codigo] = preguntaTextoSimple;
        this.tbPregunta.Text = preguntaTextoSimple.GlosaPregunta;
        this.tbAnotacionPregunta.Text = preguntaTextoSimple.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = preguntaTextoSimple.NotaAdicionalFinalPregunta;
        this.hiddenCodigoPregunta.Value = preguntaTextoSimple.Codigo;
    }

    private Pregunta recogerInformacion()
    {
        Pregunta resultado = (Pregunta)ViewState[this.hiddenCodigoPregunta.Value];
        resultado.GlosaPregunta = this.tbPregunta.Text;
        resultado.NotaAdicionalPregunta = this.tbAnotacionPregunta.Text;
        resultado.NotaAdicionalFinalPregunta = this.tbAnotacionFinalPregunta.Text;
        return resultado;
    }

    public void recogerInformacion(Pregunta resultado)
    {
        resultado.GlosaPregunta = this.tbPregunta.Text;
        resultado.NotaAdicionalPregunta = this.tbAnotacionPregunta.Text;
        resultado.NotaAdicionalFinalPregunta = this.tbAnotacionFinalPregunta.Text;
    }
}
