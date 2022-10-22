using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Utils.Exceptions;

public partial class Mantenedores_Conexiones_Listar : PaginaBaseAutenticable
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (!String.IsNullOrEmpty(Request.QueryString["mensaje"]))
            base.mensajeDialog(Request.QueryString["mensaje"]);
    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            GestionadorAccesador gestionador = new GestionadorAccesador();
            if (!e.IsFromDetailTable)
            {
                radGridCadenasConexion.DataSource = gestionador.ObtenerCadenasConexion();
            }
        }
        catch (ActionableException ex)
        {
        }
        catch (Exception ex)
        {
        }
    }
}
