using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Pulse.Contactador.Dto;

public partial class Encuestas_PanelControl_OpcionUnica : WebUserControlPreguntaBase
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
        PreguntaOpcionUnica preguntaOpcionUnica = pregunta as PreguntaOpcionUnica;
        if (preguntaOpcionUnica == null) return;
        ViewState[pregunta.Codigo] = preguntaOpcionUnica;
        this.tbPregunta.Text = preguntaOpcionUnica.GlosaPregunta;
        this.tbAnotacionPregunta.Text = preguntaOpcionUnica.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = preguntaOpcionUnica.NotaAdicionalFinalPregunta;
        this.hiddenCodigoPregunta.Value = preguntaOpcionUnica.Codigo;
        if (preguntaOpcionUnica.Items != null)
        {
            foreach (ItemPregunta cadaItemPregunta in preguntaOpcionUnica.Items)
            {
                this.listboxOpciones.Items.Add(new RadListBoxItem(cadaItemPregunta.GlosaPregunta));
            }
        }
        this.checkListConfiguracion.Items.FindByValue("Obligario").Selected = preguntaOpcionUnica.Obligatorio;
        this.checkListConfiguracion.Items.FindByValue("Otro").Selected = preguntaOpcionUnica.OtraOpcion;
        this.checkListConfiguracion.Items.FindByValue("Combobox").Selected = preguntaOpcionUnica.PresentarEnCombobox;
        this.checkListConfiguracion.Items.FindByValue("Aleatorio").Selected = preguntaOpcionUnica.PresentarAleatoriamente;
        this.checkListConfiguracion.Items.FindByValue("Horizontal").Selected = preguntaOpcionUnica.PresentarHorizontal;
    }

    private Pregunta recogerInformacion()
    {
        PreguntaOpcionUnica resultado = (PreguntaOpcionUnica)ViewState[this.hiddenCodigoPregunta.Value];
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
        resultado.PresentarEnCombobox = this.checkListConfiguracion.Items.FindByValue("Combobox").Selected;
        resultado.PresentarAleatoriamente = this.checkListConfiguracion.Items.FindByValue("Aleatorio").Selected;
        resultado.PresentarHorizontal = this.checkListConfiguracion.Items.FindByValue("Horizontal").Selected;
        return resultado;
    }

    public void recogerInformacion(Pregunta pregunta)
    {
        PreguntaOpcionUnica resultado = pregunta as PreguntaOpcionUnica;
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
        resultado.PresentarEnCombobox = this.checkListConfiguracion.Items.FindByValue("Combobox").Selected;
        resultado.PresentarAleatoriamente = this.checkListConfiguracion.Items.FindByValue("Aleatorio").Selected;
        resultado.PresentarHorizontal = this.checkListConfiguracion.Items.FindByValue("Horizontal").Selected;
    }


}
