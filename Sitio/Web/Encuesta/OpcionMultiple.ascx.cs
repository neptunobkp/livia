using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using System.Text;

public partial class Web_Encuesta_OpcionMultiple : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
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
        this.tbPregunta.Text = value.GlosaPregunta;
        this.tbAnotacionPregunta.Text = value.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = value.NotaAdicionalFinalPregunta;
        foreach (var cadaItem in (value as PreguntaOpcionMultiple).Items)
        {
            this.checkboxListOpciones.Items.Add(new ListItem(cadaItem.GlosaPregunta, cadaItem.Id.ToString()));
        }
        if ((value as PreguntaOpcionMultiple).OtraOpcion)
        {
            this.checkboxListOpciones.Items.Add(new ListItem("Otro", "0"));
            this.radTextboxOtraOpcion.Visible = true;
        }
    }


    private void configurarPrimerItemParaValidacion(ListItem listItem, PreguntaOpcionMultiple preguntaOpcionMultiple)
    {
        StringBuilder contextoValidacion = new StringBuilder();
        if (preguntaOpcionMultiple.Obligatorio)
            contextoValidacion.Append("required:true,");
        if (preguntaOpcionMultiple.LimiteMaximoSeleccionables > 0)
            contextoValidacion.Append(String.Format("maxlength:{0},", preguntaOpcionMultiple.LimiteMaximoSeleccionables));
        if (preguntaOpcionMultiple.LimiteMinimoSeleccionables > 0)
            contextoValidacion.Append(String.Format("minlength:{0},", preguntaOpcionMultiple.LimiteMinimoSeleccionables));

        if (contextoValidacion.ToString().Length > 0)
            listItem.Attributes.Add("validate", contextoValidacion.ToString().Substring(0, contextoValidacion.ToString().Length - 1));
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
