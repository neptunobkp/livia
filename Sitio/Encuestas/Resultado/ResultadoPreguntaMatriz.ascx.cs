using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;

public partial class Encuestas_Resultado_ResultadoPreguntaMatriz : System.Web.UI.UserControl
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

        string ras = String.Empty;
        this.tbPregunta.Text = value.GlosaPregunta;
        this.tbAnotacionPregunta.Text = value.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = value.NotaAdicionalFinalPregunta;
        this.repeaterCabezera.DataSource = (value as PreguntaMatriz).ItemsColumnas;
        this.repeaterCabezera.DataBind();
        this.repeaterPreguntas.DataSource = ConfigurarPresentadoresFilaMatriz((value as PreguntaMatriz).ItemsFilas, (value as PreguntaMatriz).ItemsColumnas);
        this.repeaterPreguntas.DataBind();
    }

    private List<PresentadorFilaMatriz> ConfigurarPresentadoresFilaMatriz(List<ItemPregunta> itemsFilas, List<ItemPregunta> itemsColumnas)
    {
        List<PresentadorFilaMatriz> resultado = new List<PresentadorFilaMatriz>();
        foreach (var cadaItemFila in itemsFilas)
        {
            PresentadorFilaMatriz itemPresentadorFilaMatriz = new PresentadorFilaMatriz();
            itemPresentadorFilaMatriz.NombrePregunta = cadaItemFila.GlosaPregunta;
            itemPresentadorFilaMatriz.IdentificadorFila = cadaItemFila.Id;
            itemPresentadorFilaMatriz.ItemsPreguntas = new List<ItemPregunta>();
            foreach (var cadaItemColuma in itemsColumnas)
                itemPresentadorFilaMatriz.ItemsPreguntas.Add(new ItemPregunta()
                {
                    Id = cadaItemColuma.Id,
                    GlosaPregunta = cadaItemColuma.GlosaPregunta,
                    NombreGrupo = cadaItemFila.Id.ToString()
                });
            resultado.Add(itemPresentadorFilaMatriz);
        }
        return resultado;
    }


    public void RecogerRespuestas(Respuesta respuesta, Pregunta preguntaRespondida)
    {
        foreach (RepeaterItem cadaItem in this.repeaterPreguntas.Items)
        {
            ItemRespuesta itemRespuesta = new ItemRespuesta();
            itemRespuesta.PregunaRespondida = new Pregunta() { Id = preguntaRespondida.Id };
            itemRespuesta.TipoPreguntaRespondida = preguntaRespondida.TipoPregunta;
            leerInformacionItemRepeater(itemRespuesta, cadaItem);
            respuesta.ItemsRespuestas.Add(itemRespuesta);
        }

    }

    private void leerInformacionItemRepeater(ItemRespuesta itemRespuesta, RepeaterItem cadaItem)
    {
        itemRespuesta.GlosaRespuesta = ((Label)cadaItem.FindControl("lblNombreSubPregunta")).Text;
        itemRespuesta.ValorRespuesta = ((HiddenField)cadaItem.FindControl("hiddenItemPreguntaId")).Value;
        String valorSeleccionadoRadio = Request.Form[itemRespuesta.ValorRespuesta];
        Repeater repeaterOpciones = cadaItem.FindControl("repeaterItemsAlternativas") as Repeater;
        foreach (RepeaterItem cadaRepetarItem in repeaterOpciones.Items)
        {
            if (((HiddenField)cadaRepetarItem.FindControl("hiddenSubItemColumnaPreguntaId")).Value == valorSeleccionadoRadio)
            {
                itemRespuesta.GlosaTipoColumna = ((HiddenField)cadaRepetarItem.FindControl("hiddenGlosaPregunta")).Value;
                itemRespuesta.ValorTipoColumna = valorSeleccionadoRadio;
            }
        }
    }

    public void EstablecerRespuesta(List<ItemRespuesta> itemsPreguntas)
    {
        foreach (RepeaterItem cadaRepeaterItem in this.repeaterPreguntas.Items)
        {
            int idPreguntaRepeater = Convert.ToInt32(((HiddenField)cadaRepeaterItem.FindControl("hiddenItemPreguntaId")).Value);
            Repeater repeaterOpciones = (Repeater)cadaRepeaterItem.FindControl("repeaterItemsAlternativas");
            foreach (RepeaterItem cadaRepeaterItemAlternativa in repeaterOpciones.Items)
            {
                int _hiddenSubItemColumnaPreguntaId = Convert.ToInt32(((HiddenField)cadaRepeaterItemAlternativa.FindControl("hiddenSubItemColumnaPreguntaId")).Value);
                RadioButton radioAlternativo = cadaRepeaterItemAlternativa.FindControl("radioAlternativa") as RadioButton;
                if (itemsPreguntas.Any(t => t.ValorRespuesta == idPreguntaRepeater.ToString()))
                {
                    var itemPreguntaResultado = itemsPreguntas.First(t => t.ValorRespuesta == idPreguntaRepeater.ToString());
                    if (_hiddenSubItemColumnaPreguntaId.ToString() == itemPreguntaResultado.ValorTipoColumna)
                        radioAlternativo.Checked = true;
                }
            }
        }
    }
}
