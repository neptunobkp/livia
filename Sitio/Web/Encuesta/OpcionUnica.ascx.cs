using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;

public partial class Web_Encuesta_OpcionUnica : System.Web.UI.UserControl
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

    private void cargarControls(Pregunta value)
    {
        this.reuiqreOpcion.ErrorMessage = value.NotaAdicionalPregunta;
        this.tbPregunta.Text = value.GlosaPregunta;

        this.tbAnotacionPregunta.Text = value.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = value.NotaAdicionalFinalPregunta;
        this.checkboxListOpciones.DataSource = (value as PreguntaOpcionUnica).Items;
        this.checkboxListOpciones.DataTextField = "GlosaPregunta";
        this.checkboxListOpciones.DataValueField = "Id";
        this.checkboxListOpciones.DataBind();
        this.checkboxListOpciones.RepeatDirection = RepeatDirection.Horizontal;
        this.radTextboxOtraOpcion.Visible = (value as PreguntaOpcionUnica).OtraOpcion;
    }

    public void RecogerRespuestas(Respuesta respuesta, Pregunta preguntaRespondida)
    {
        foreach (ListItem cadaListItem in checkboxListOpciones.Items)
        {
            if (cadaListItem.Selected)
            {
                ItemRespuesta itemRespuesta = new ItemRespuesta();
                itemRespuesta.PregunaRespondida = new Pregunta() { Id = preguntaRespondida.Id };
                itemRespuesta.TipoPreguntaRespondida = preguntaRespondida.TipoPregunta;
                itemRespuesta.ValorRespuesta = cadaListItem.Value;
                itemRespuesta.GlosaRespuesta = cadaListItem.Text;
                respuesta.ItemsRespuestas.Add(itemRespuesta);
            }
        }
    }
}
