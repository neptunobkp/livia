using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Pulse.Contactador.Dto;

public partial class Encuestas_PanelControl_PreguntaMatriz : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAgregarA_Click(object sender, EventArgs e)
    {
        this.listboxOpcionesA.Items.Add(new RadListBoxItem(""));
    }

    protected void btnAgregarB_Click(object sender, EventArgs e)
    {
        this.listboxOpcionesB.Items.Add(new RadListBoxItem(""));
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
        PreguntaMatriz preguntaMatriz = pregunta as PreguntaMatriz;
        if (preguntaMatriz == null) return;
        ViewState[pregunta.Codigo] = preguntaMatriz;
        this.tbPregunta.Text = preguntaMatriz.GlosaPregunta;
        this.tbAnotacionPregunta.Text = preguntaMatriz.NotaAdicionalPregunta;
        this.tbAnotacionFinalPregunta.Text = preguntaMatriz.NotaAdicionalFinalPregunta;
        this.hiddenCodigoPregunta.Value = preguntaMatriz.Codigo;

        if (preguntaMatriz.ItemsColumnas != null)
            foreach (ItemPregunta cadaItemPregunta in preguntaMatriz.ItemsColumnas)
                this.listboxOpcionesA.Items.Add(new RadListBoxItem(cadaItemPregunta.GlosaPregunta));

        if (preguntaMatriz.ItemsFilas != null)
            foreach (ItemPregunta cadaItemPregunta in preguntaMatriz.ItemsFilas)
                this.listboxOpcionesB.Items.Add(new RadListBoxItem(cadaItemPregunta.GlosaPregunta));

        this.checkListConfiguracion.Items.FindByValue("Obligario").Selected = preguntaMatriz.Obligatorio;

    }

    private Pregunta recogerInformacion()
    {
        PreguntaOpcionMultiple resultado = (PreguntaOpcionMultiple)ViewState[this.hiddenCodigoPregunta.Value];
        recogerInformacion(resultado);
        return resultado;
    }

    public void recogerInformacion(Pregunta pregunta)
    {
        PreguntaMatriz resultado = pregunta as PreguntaMatriz;
        recogerInformacion(resultado);
    }

    private void recogerInformacion(PreguntaMatriz resultado)
    {
        resultado.GlosaPregunta = this.tbPregunta.Text;
        resultado.NotaAdicionalPregunta = this.tbAnotacionPregunta.Text;
        resultado.NotaAdicionalFinalPregunta = this.tbAnotacionFinalPregunta.Text;
        resultado.ItemsColumnas = new List<ItemPregunta>();
        resultado.ItemsFilas = new List<ItemPregunta>();

        foreach (RadListBoxItem item in this.listboxOpcionesA.Items)
            resultado.ItemsColumnas.Add(new ItemPregunta() { GlosaPregunta = ((TextBox)item.FindControl("tbItemOpcionesAText")).Text, TipoItemPregunta = TiposItemPregunta.ColumnaMatriz });

        foreach (RadListBoxItem item in this.listboxOpcionesB.Items)
            resultado.ItemsFilas.Add(new ItemPregunta() { GlosaPregunta = ((TextBox)item.FindControl("tbItemOpcionesBText")).Text, TipoItemPregunta = TiposItemPregunta.FliaMatriz });


        resultado.Obligatorio = this.checkListConfiguracion.Items.FindByValue("Obligario").Selected;
    }
}
