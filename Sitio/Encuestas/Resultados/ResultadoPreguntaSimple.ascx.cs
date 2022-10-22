using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dto;

public partial class Encuestas_Resultados_ResultadoPreguntaSimple : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int CantidadRespuestas
    {
        get
        {
            if (String.IsNullOrEmpty(this.hiddenCantidadRespuesta.Value))
                return 0;
            else
                return Convert.ToInt32(this.hiddenCantidadRespuesta.Value);
        }
        set
        {
            this.hiddenCantidadRespuesta.Value = value.ToString();
        }
    }

    public Pregunta preguntainterna
    {
        set
        {
            if (value == null) return;
            cargarResultado(value);
        }
    }

    private void cargarResultado(Pregunta pregunta)
    {
        this.tbPregunta.Text = pregunta.GlosaPregunta;
        this.tbAnotacionPregunta.Text = pregunta.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = pregunta.NotaAdicionalFinalPregunta;
        List<ItemRespuesta> itemesRespuesta = new GestionadorResultadoEncuesta().ObtenerItemsRespuestaPorPreguntaId(pregunta.Id);
        this.repeaterTextos.DataSource = itemesRespuesta;
        this.repeaterTextos.DataBind();
    }
}
