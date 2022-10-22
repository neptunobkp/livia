using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;

public partial class Encuestas_PanelControl_PaginaEncuesta : System.Web.UI.UserControl
{
    public List<Pregunta> ViewStatesPreguntas
    {
        get { return (List<Pregunta>)ViewState["ViewStatesPreguntas"]; }
        set { ViewState["ViewStatesPreguntas"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        this.ViewStatesPreguntas = new List<Pregunta>();
    }

    public void CompletarInfoPagina(Pagina pagina)
    {
        pagina.Titulo = this.tbTituloPagina.Text;
        pagina.IntroduccionPagina = this.tbIntroduccionPagina.Text;
    }

    public void RecargarPreguntas()
    {
        foreach (RepeaterItem cadaRepeaterItem in repeaterPreguntas.Items)
        {
            HiddenField hiddenFieldTipoPregunta = (HiddenField)cadaRepeaterItem.FindControl("hiddenTipoPregunta");
            HiddenField hiddenFieldCodigoPregunta = (HiddenField)cadaRepeaterItem.FindControl("hiddenCodigoPreugnta");
            if (hiddenFieldTipoPregunta.Value == "SeleccionMultiple")
            {
                Encuestas_PanelControl_OpcionMultiple controlOpcionMultiple = (Encuestas_PanelControl_OpcionMultiple)cadaRepeaterItem.FindControl("preguntaSeleccionMultiple");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "SeleccionUnica")
            {
                Encuestas_PanelControl_OpcionUnica controlOpcionMultiple = (Encuestas_PanelControl_OpcionUnica)cadaRepeaterItem.FindControl("preguntaOpcionUnica");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "TextoSimple")
            {
                Encuestas_PanelControl_PreguntaSimple controlOpcionMultiple = (Encuestas_PanelControl_PreguntaSimple)cadaRepeaterItem.FindControl("preguntaTextoSimple");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "TextoEnsayo")
            {
                Encuestas_PanelControl_PreguntaParrafo controlOpcionMultiple = (Encuestas_PanelControl_PreguntaParrafo)cadaRepeaterItem.FindControl("preguntaTextoEnsayo");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "Matriz")
            {
                Encuestas_PanelControl_PreguntaMatriz controlOpcionMultiple = (Encuestas_PanelControl_PreguntaMatriz)cadaRepeaterItem.FindControl("preguntaMatriz");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
        }

        this.repeaterPreguntas.DataSource = this.ViewStatesPreguntas;
        this.repeaterPreguntas.DataBind();
    }

    public List<Pregunta> RecogerPreguntasRecargadas()
    {
        foreach (RepeaterItem cadaRepeaterItem in repeaterPreguntas.Items)
        {
            HiddenField hiddenFieldTipoPregunta = (HiddenField)cadaRepeaterItem.FindControl("hiddenTipoPregunta");
            HiddenField hiddenFieldCodigoPregunta = (HiddenField)cadaRepeaterItem.FindControl("hiddenCodigoPreugnta");
            if (hiddenFieldTipoPregunta.Value == "SeleccionMultiple")
            {
                Encuestas_PanelControl_OpcionMultiple controlOpcionMultiple = (Encuestas_PanelControl_OpcionMultiple)cadaRepeaterItem.FindControl("preguntaSeleccionMultiple");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "SeleccionUnica")
            {
                Encuestas_PanelControl_OpcionUnica controlOpcionMultiple = (Encuestas_PanelControl_OpcionUnica)cadaRepeaterItem.FindControl("preguntaOpcionUnica");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "TextoSimple")
            {
                Encuestas_PanelControl_PreguntaSimple controlOpcionMultiple = (Encuestas_PanelControl_PreguntaSimple)cadaRepeaterItem.FindControl("preguntaTextoSimple");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "TextoEnsayo")
            {
                Encuestas_PanelControl_PreguntaParrafo controlOpcionMultiple = (Encuestas_PanelControl_PreguntaParrafo)cadaRepeaterItem.FindControl("preguntaTextoEnsayo");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
            else if (hiddenFieldTipoPregunta.Value == "Matriz")
            {
                Encuestas_PanelControl_PreguntaMatriz controlOpcionMultiple = (Encuestas_PanelControl_PreguntaMatriz)cadaRepeaterItem.FindControl("preguntaMatriz");
                if (this.ViewStatesPreguntas.Any(t => t.Codigo == hiddenFieldCodigoPregunta.Value))
                {
                    Pregunta pregunta = this.ViewStatesPreguntas.Single(t => t.Codigo == hiddenFieldCodigoPregunta.Value);
                    controlOpcionMultiple.recogerInformacion(pregunta);
                }
            }
        }
        return this.ViewStatesPreguntas;
    }

    protected void btnAgregarPreguntaOpcionMultiple_Click(object sender, EventArgs e)
    {
        this.ViewStatesPreguntas.Add(new PreguntaOpcionMultiple() { Codigo = Guid.NewGuid().ToString(), TipoPregunta = TiposPregunta.SeleccionMultiple });
        RecargarPreguntas();
        linkbtnAgregarPreguntaOpcionMultiple.Focus();
    }

    protected void btnAgregarPreguntaOpcionUnica_Click(object sender, EventArgs e)
    {
        this.ViewStatesPreguntas.Add(new PreguntaOpcionUnica() { Codigo = Guid.NewGuid().ToString(), TipoPregunta = TiposPregunta.SeleccionUnica });
        RecargarPreguntas();
        linkAgregarPreguntaOpcionUnica.Focus();
    }

    protected void linkAgregarPreguntaSimple_Click(object sender, EventArgs e)
    {
        this.ViewStatesPreguntas.Add(new Pregunta() { Codigo = Guid.NewGuid().ToString(), TipoPregunta = TiposPregunta.TextoSimple });
        RecargarPreguntas();
        linkAgregarPreguntaOpcionUnica.Focus();
    }

    protected void linkAgregarPreguntaEnsayo_Click(object sender, EventArgs e)
    {
        this.ViewStatesPreguntas.Add(new Pregunta() { Codigo = Guid.NewGuid().ToString(), TipoPregunta = TiposPregunta.TextoEnsayo });
        RecargarPreguntas();
        linkAgregarPreguntaOpcionUnica.Focus();
    }

    protected void linkAgregarPreguntaMatriz_Click(object sender, EventArgs e)
    {
        this.ViewStatesPreguntas.Add(new PreguntaMatriz() { Codigo = Guid.NewGuid().ToString(), TipoPregunta = TiposPregunta.Matriz });
        RecargarPreguntas();
        linkAgregarPreguntaOpcionUnica.Focus();
    }

    public void Mover<T>(List<T> list, int oldIndex, int newIndex)
    {
        T aux = list[newIndex];
        list[newIndex] = list[oldIndex];
        list[oldIndex] = aux;
    }

    protected void repeaterPreguntas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Bajar")
        {
            Pregunta preguntaSeleccionada = this.ViewStatesPreguntas.Single(t => t.Codigo == e.CommandArgument.ToString());
            int actualIndex = this.ViewStatesPreguntas.IndexOf(preguntaSeleccionada);
            Mover<Pregunta>(this.ViewStatesPreguntas, actualIndex, actualIndex + 1);
            RecargarPreguntas();
        }
        else if (e.CommandName == "Subir")
        {
            Pregunta preguntaSeleccionada = this.ViewStatesPreguntas.Single(t => t.Codigo == e.CommandArgument.ToString());
            int actualIndex = this.ViewStatesPreguntas.IndexOf(preguntaSeleccionada);
            Mover<Pregunta>(this.ViewStatesPreguntas, actualIndex, actualIndex - 1);
            RecargarPreguntas();
        }
        else if (e.CommandName == "Eliminar")
        {
            Pregunta preguntaSeleccionada = this.ViewStatesPreguntas.Single(t => t.Codigo == e.CommandArgument.ToString());
            int actualIndex = this.ViewStatesPreguntas.IndexOf(preguntaSeleccionada);
            this.ViewStatesPreguntas.Remove(preguntaSeleccionada);
            RecargarPreguntas();
        }
    }
}
