using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

/// <summary>
/// Summary description for PaginaBaseExterna
/// </summary>
public class PaginaBaseExterna : System.Web.UI.Page
{

    protected void executeJqueryScript(String jqueryScript)
    {
        try
        {
            ScriptManager requestSM = ScriptManager.GetCurrent(this);
            if (requestSM != null && requestSM.IsInAsyncPostBack)
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), Guid.NewGuid().ToString(), JQueryBuilderHelper.getjQueryCode(jqueryScript), true);
            else
                ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), JQueryBuilderHelper.getjQueryCode(jqueryScript), true);
        }
        catch (Exception ex)
        {
        }
    }

   


}
