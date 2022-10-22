using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using Telerik.Charting;

public partial class Encuestas_Resultados_ResultadoPreguntaOpcionMatriz : System.Web.UI.UserControl
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
        List<ItemRespuesta> itemesRespuesta = new GestionadorResultadoEncuesta().ObtenerItemsRespuestaPorPreguntaId(pregunta.Id);
        this.tbPregunta.Text = pregunta.GlosaPregunta;
        this.tbAnotacionPregunta.Text = pregunta.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = pregunta.NotaAdicionalFinalPregunta;
        this.repeaterCabezera.DataSource = (pregunta as PreguntaMatriz).ItemsColumnas;
        this.repeaterCabezera.DataBind();
        this.repeaterPreguntas.DataSource = ConfigurarPresentadoresFilaMatriz(itemesRespuesta, (pregunta as PreguntaMatriz).ItemsFilas, (pregunta as PreguntaMatriz).ItemsColumnas);
        this.repeaterPreguntas.DataBind();
    }


    private List<PresentadorFilaMatriz> ConfigurarPresentadoresFilaMatriz(List<ItemRespuesta> itemesRespuesta, List<ItemPregunta> itemsFilas, List<ItemPregunta> itemsColumnas)
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
                    ValorInterno = calcularPorcentaje(itemesRespuesta, cadaItemColuma.Id, cadaItemFila.Id)
                });
            resultado.Add(itemPresentadorFilaMatriz);
        }
        return resultado;
    }

    private string calcularPorcentaje(List<ItemRespuesta> itemesRespuesta, int cadaitemcolumnaId, int cadaitemfilaId)
    {
        return itemesRespuesta.Count(t => t.ValorTipoColumna == cadaitemcolumnaId.ToString() && t.ValorRespuesta == cadaitemfilaId.ToString()).ToString();
    }

    protected void RadChart2_ItemDataBound(object sender, ChartItemDataBoundEventArgs e)
    {
        e.SeriesItem.Name = (string)DataBinder.Eval(e.DataItem, "Glosa");
    }
}

