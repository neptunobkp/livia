using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Utils.Exceptions;

public partial class Encuestas_Resultados_VerRespuestas : System.Web.UI.Page
{
    public int ViewStateEncuestaId
    {
        get { return (int)ViewState["ViewStateEncuestaId"]; }
        set { ViewState["ViewStateEncuestaId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        this.ViewStateEncuestaId = Convert.ToInt32(Request.Params["encuestaId"]);
    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            GestionadorResultadoEncuesta gestionadorResultado = new GestionadorResultadoEncuesta();
            if (!e.IsFromDetailTable)
            {
                radGridEncuestas.DataSource = gestionadorResultado.ObtenerRespuestasPorEncuestaId(this.ViewStateEncuestaId);
            }
        }
        catch (ActionableException)
        {
        }
        catch (Exception ex)
        {
        }
    }
}
