using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic;
using Pulse.Utils.Exceptions;

public partial class Mantenedores_Plantillas_Listar : PaginaBaseAutenticable
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
            if (!e.IsFromDetailTable) radGridPlantillas.DataSource = new GestionadorPlantilla().ObtenerPlantillas();
        }
        catch (Exception ex)
        {
            base.mensajeDialog(ex.Message);
        }
    }

    protected void grid_oncommmand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Modificar": Response.Redirect("Editar?id=" + e.CommandArgument); break;
            case "Eliminar": EliminarRegistro(Convert.ToInt32(e.CommandArgument)); break;
            default: break;
        }
    }

    private void EliminarRegistro(int identificador)
    {
        new GestionadorPlantilla().EliminarPlantilla(identificador);
        this.radGridPlantillas.MasterTableView.Rebind();
        base.mensajeDialog("Se ha eliminado la plantilla correctamente.");
    }
}
