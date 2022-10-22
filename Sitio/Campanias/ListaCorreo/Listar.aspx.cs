using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Pulse.Contactador.BusinessLogic;

public partial class Campanias_ListaCorreo_Listar : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (!String.IsNullOrEmpty(Request.QueryString["mensaje"]))
            base.mensajeDialog(Request.QueryString["mensaje"]);
    }

    protected void radGridListasCorreo_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        GestionadorListaCorreo gestionador = new GestionadorListaCorreo();
        this.radGridListasCorreo.DataSource = gestionador.ObtenerListasCorreo();
    }
}
