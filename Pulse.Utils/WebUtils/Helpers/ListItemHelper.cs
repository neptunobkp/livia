using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;

namespace Pulse.Utils.WebUtils.Helpers
{
    public class ListItemHelper
    {
        public static void PoblarListControl(IList listSource, String textField, String valueField, ListControl listControl)
        {
            listControl.DataSource = listSource;
            listControl.DataTextField = textField;
            listControl.DataValueField = valueField;
            listControl.DataBind();
        }
    }
}
