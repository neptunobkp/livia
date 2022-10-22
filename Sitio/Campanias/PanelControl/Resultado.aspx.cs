using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Telerik.Web.UI;

public partial class Campanias_PanelControl_Resultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        this.hiddenListaCorreoId.Value = Request.QueryString["id"];
    }

    protected void radGridListaCorreo_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        GestionadorListaCorreo gestionador = new GestionadorListaCorreo();
        this.radGridListaCorreo.DataSource = gestionador.ObtenerListaCorreo(Convert.ToInt32(this.hiddenListaCorreoId.Value)).CorreosDestino;
    }
}
