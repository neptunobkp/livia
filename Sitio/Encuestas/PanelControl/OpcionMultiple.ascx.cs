using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Pulse.Contactador.Dto;

public partial class Encuestas_PanelControl_OpcionMultiple : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        this.listboxOpciones.Items.Add(new RadListBoxItem(""));
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

    private void presentarInformacion(Pregunta pregunta)
    {
        PreguntaOpcionMultiple preguntaMultiple = pregunta as PreguntaOpcionMultiple;
        if (preguntaMultiple == null) return;
        ViewState[pregunta.Codigo] = preguntaMultiple;
        this.tbPregunta.Text = preguntaMultiple.GlosaPregunta;
        this.tbAnotacionPregunta.Text = preguntaMultiple.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = preguntaMultiple.NotaAdicionalFinalPregunta;
        this.hiddenCodigoPregunta.Value = preguntaMultiple.Codigo;
        if (preguntaMultiple.Items != null)
        {
            foreach (ItemPregunta cadaItemPregunta in preguntaMultiple.Items)
            {
                this.listboxOpciones.Items.Add(new RadListBoxItem(cadaItemPregunta.GlosaPregunta));
            }
        }

        this.checkListConfiguracion.Items.FindByValue("Obligario").Selected = preguntaMultiple.Obligatorio;
        this.checkListConfiguracion.Items.FindByValue("Otro").Selected = preguntaMultiple.OtraOpcion;
        this.checkListConfiguracion.Items.FindByValue("Aleatorio").Selected = preguntaMultiple.PresentarAleatoriamente;

        this.tbNumeroColumnas.Value = preguntaMultiple.CantidadColumnasPresentacion.GetValueOrDefault(1);
        this.tbNumeroMaximoItemsSeleccionado.Value = preguntaMultiple.LimiteMaximoSeleccionables.GetValueOrDefault(0);
    }

    private Pregunta recogerInformacion()
    {
        PreguntaOpcionMultiple resultado = (PreguntaOpcionMultiple)ViewState[this.hiddenCodigoPregunta.Value];
        recogerInformacion(resultado);
        return resultado;
    }

    public void recogerInformacion(Pregunta pregunta)
    {
        PreguntaOpcionMultiple resultado = pregunta as PreguntaOpcionMultiple;
        recogerInformacion(resultado);
    }

    private void recogerInformacion(PreguntaOpcionMultiple resultado)
    {
        resultado.GlosaPregunta = this.tbPregunta.Text;
        resultado.NotaAdicionalPregunta = this.tbAnotacionPregunta.Text;
        resultado.NotaAdicionalFinalPregunta = this.tbAnotacionFinalPregunta.Text;
        resultado.Items = new List<ItemPregunta>();
        foreach (RadListBoxItem item in this.listboxOpciones.Items)
        {
            resultado.Items.Add(new ItemPregunta() { GlosaPregunta = ((TextBox)item.FindControl("tbItemOpcionesText")).Text });
        }

        resultado.Obligatorio = this.checkListConfiguracion.Items.FindByValue("Obligario").Selected;
        resultado.OtraOpcion = this.checkListConfiguracion.Items.FindByValue("Otro").Selected;
        resultado.PresentarAleatoriamente = this.checkListConfiguracion.Items.FindByValue("Aleatorio").Selected;
        resultado.CantidadColumnasPresentacion = Convert.ToInt32(this.tbNumeroColumnas.Value.GetValueOrDefault(1));
        resultado.LimiteMaximoSeleccionables = Convert.ToInt32(this.tbNumeroMaximoItemsSeleccionado.Value.GetValueOrDefault(0));
    }



}
