using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Utils.Exceptions;

public partial class Encuestas_PanelControl_Listar : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (!String.IsNullOrEmpty(Request.QueryString["mensaje"])) base.mensajeDialog(Request.QueryString["mensaje"]);
    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            GestionadorResultadoEncuesta gestionadorResultado = new GestionadorResultadoEncuesta();
            if (!e.IsFromDetailTable)
            {
                radGridEncuestas.DataSource = gestionadorResultado.ObtenerTodasLasEncuestas();
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
