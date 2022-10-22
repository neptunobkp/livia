using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//// <summary>
//// Summary description for ControlsHelper
//// </summary>
public class ControlsHelper
{


    public static void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {
                String control = c.GetType().ToString();
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = string.Empty;
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).SelectedValue = "";
                        break;
                    //case "Telerik.Web.UI.DatePickingInput":
                    //    ((Telerik.Web.UI.DateInputSetting)c).EmptyMessage= String.Empty;
                    //    break;
                }
            }
        }
    }


    public static void LimpiarFormularioDynamico(ControlCollection controlCollection)
    {
        foreach (Control cadaControl in controlCollection)
            ResetFormControlValues(cadaControl);
    }
}
