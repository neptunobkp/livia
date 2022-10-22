using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pulse.Contactador.Dto;
using System.Web.UI;
using Pulse.Utils.Exceptions;

/// <summary>
/// Summary description for PaginaBaseAutenticable
/// </summary>
public class PaginaBaseAutenticable : System.Web.UI.Page
{
    public PaginaBaseAutenticable()
    {
    }

    public Usuario SessionUsuarioContactador
    {
        get { return Session.Contents["SessionUsuarioContactador"] as Usuario; }
        set { Session["SessionUsuarioContactador"] = value; }
    }

    public void mensajeDialog(String mensaje)
    {
        try
        {
            ScriptManager requestSM = ScriptManager.GetCurrent(this);
            if (requestSM != null && requestSM.IsInAsyncPostBack)
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Guid.NewGuid().ToString(), JQueryBuilderHelper.jquerydialog(mensaje, "panel-mensaje-popup"), true);
            else
                ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), JQueryBuilderHelper.jquerydialog(mensaje, "panel-mensaje-popup"), true);
        }
        catch (Exception ex)
        {
            LoggerManager.LogError("error al mostrar un mensaje", TiposCategoryLog.LogWEB, ex);
        }
    }


}
