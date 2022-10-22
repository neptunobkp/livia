using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dto;
using System.Data;
using Telerik.Charting;
using System.Drawing;

public partial class Encuestas_Resultados_ResultadoPreguntaOpcionUnica : System.Web.UI.UserControl
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

        List<ItemResultadoEncuesta> itemsResultadosEncuesta = new List<ItemResultadoEncuesta>();
        List<ItemRespuesta> itemesRespuesta = new GestionadorResultadoEncuesta().ObtenerItemsRespuestaPorPreguntaId(pregunta.Id);

        //ChartSeries chartSeriePregunta = new ChartSeries("Opciones", ChartSeriesType.Pie);
        foreach (ItemPregunta cadaItemPregunta in (pregunta as PreguntaOpcionUnica).Items)
        {
            var itemsRespuestasDeItemPregunta = itemesRespuesta.Where(t => t.ValorRespuesta == cadaItemPregunta.Id.ToString());
            ItemResultadoEncuesta itemResultadoEncuesta = new ItemResultadoEncuesta();
            itemResultadoEncuesta.Porcentaje = this.CantidadRespuestas == 0 ? 0 : Decimal.Round((decimal)(itemsRespuestasDeItemPregunta.Count() * 100) / CantidadRespuestas, 1);
            itemResultadoEncuesta.Cantidad = itemsRespuestasDeItemPregunta.Count();
            itemResultadoEncuesta.Glosa = cadaItemPregunta.GlosaPregunta;
            itemsResultadosEncuesta.Add(itemResultadoEncuesta);
            //chartSeriePregunta.Items.Add(new ChartSeriesItem(itemResultadoEncuesta.Cantidad, itemResultadoEncuesta.Glosa));
        }

        this.radChartItemsPastel.DataSource = itemsResultadosEncuesta;
        this.radChartItemsPastel.Series.Add(new Telerik.Charting.ChartSeries() { DataYColumn = "Cantidad", Name = "Opciones" });
        this.radChartItemsPastel.DataBind();


        //this.radChartItemsPastel.Series.Add(chartSeriePregunta);
        //this.radChartItemsPastel.Skin = "LightBlue";
        //this.radChartItemsPastel.DataBind();
    }

    protected void RadChart2_ItemDataBound(object sender, ChartItemDataBoundEventArgs e)
    {
        //e.SeriesItem.Name = (string)DataBinder.Eval(e.DataItem, "Glosa");
    }

}
