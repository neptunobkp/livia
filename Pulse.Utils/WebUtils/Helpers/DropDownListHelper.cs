using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using Pulse.Utils.Exceptions;

namespace Pulse.Utils.WebUtils.Helpers
{
    public class DropDownListHelper
    {
        public static void SetearItemSeleccionadoDropDownPorTexto(string texto, DropDownList dropDown)
        {
            var itemSeleccionado = dropDown.Items.FindByText(texto);
            var indexSeleccionado = dropDown.Items.IndexOf(itemSeleccionado);
            dropDown.SelectedIndex = indexSeleccionado;
        }

        public static void SetearItemSeleccionadoDropDownPorValor(string valor, DropDownList dropDown)
        {
            var itemSeleccionado = dropDown.Items.FindByValue(valor);
            var indexSeleccionado = dropDown.Items.IndexOf(itemSeleccionado);
            dropDown.SelectedIndex = indexSeleccionado;
        }


        public static void PoblarDropDownList<T>(List<T> lista, string mensajeDeSeleccion, DropDownList dropDownList)
        {
            try
            {
                dropDownList.Items.Clear();
                dropDownList.Enabled = true;
                dropDownList.DataSource = lista;
                dropDownList.DataBind();
                ListItem listItem = new ListItem();
                listItem.Text = mensajeDeSeleccion;
                listItem.Value = "";
                dropDownList.Items.Insert(0, listItem);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ha ocurrido un problema al cargar el campo ´- " + mensajeDeSeleccion + " -`");
            }
        }

        public static void PoblarDropDownList<T>(List<T> lista, string mensajeDeSeleecion,
          string dataValue, string dataText, DropDownList dropDownList)
        {
            try
            {
                dropDownList.Items.Clear();
                dropDownList.Enabled = true;
                dropDownList.DataSource = lista;
                dropDownList.DataValueField = dataValue;
                dropDownList.DataTextField = dataText;
                dropDownList.DataBind();
                ListItem listItem = new ListItem();
                listItem.Text = mensajeDeSeleecion;
                listItem.Value = "";
                dropDownList.Items.Insert(0, listItem);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ha ocurrido un problema al cargar el campo ´- " + mensajeDeSeleecion + " -`");
            }
        }

        public static void PoblarDropDownList<T>(List<T> lista, string mensajeDeSeleccion, string dataValue, string dataText, DropDownList dropDownList, string defaultValue, int defaultIndex, bool defaultEnable)
        {
            dropDownList.Items.Clear();
            dropDownList.Enabled = true;
            dropDownList.DataSource = lista;
            dropDownList.DataValueField = dataValue;
            dropDownList.DataTextField = dataText;
            dropDownList.DataBind();
            ListItem listItem = new ListItem();
            listItem.Text = mensajeDeSeleccion;
            listItem.Value = defaultValue;
            dropDownList.Items.Insert(0, listItem);
            dropDownList.SelectedIndex = defaultIndex;
            dropDownList.Enabled = defaultEnable;
        }

        public static void PoblarDropDownListConRangoNumerico(int desde, int hasta, string mensajeDeSeleecion, DropDownList dropDownList)
        {
            dropDownList.Enabled = true;
            dropDownList.Items.Clear();
            dropDownList.Items.Insert(0, new ListItem() { Text = mensajeDeSeleecion, Value = "" });
            for (int i = desde; i <= hasta; i++)
            {
                dropDownList.Items.Add(new ListItem() { Text = i.ToString(), Value = i.ToString() });
            }
            dropDownList.DataBind();
        }

        public static void PoblarDropDownListConRangoNumerico(int desde, int hasta, string mensajeDeSeleecion, DropDownList dropDownList, string complementoDerecho)
        {
            dropDownList.Enabled = true;
            dropDownList.Items.Clear();
            dropDownList.Items.Insert(0, new ListItem() { Text = mensajeDeSeleecion, Value = "" });
            for (int i = desde; i <= hasta; i++)
            {
                dropDownList.Items.Add(new ListItem() { Text = i.ToString() + " " + complementoDerecho, Value = i.ToString() });
            }
            dropDownList.DataBind();
        }

        public static void PoblaDropDonwListConEnumeracion<T>(DropDownList dropDownList)
        {
            try
            {
                ListItemCollection listItemCollection = new ListItemCollection();
                Array valoresEnum = Enum.GetValues(typeof(T));
                foreach (object valor in valoresEnum)
                {
                    string nombre = GetEnumDescription<T>((T)valor);
                    string valorEnum = Convert.ToInt32(valor).ToString();
                    if (valorEnum != "0")
                        listItemCollection.Add(new System.Web.UI.WebControls.ListItem(nombre, valorEnum));
                }
                dropDownList.Items.Clear();
                dropDownList.DataSource = listItemCollection;
                dropDownList.DataTextField = "text";
                dropDownList.DataValueField = "value";
                dropDownList.DataBind();
                ConfigurarTextoPresentacionVacio<T>(dropDownList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void LimpiarDropDownList(DropDownList dropDownList)
        {
            dropDownList.DataSource = new List<int>();
            dropDownList.DataBind();
            dropDownList.Enabled = false;
        }

        public static void LimpiarSinListaFalta(DropDownList dropDonwList)
        {
            dropDonwList.Items.Clear();
            dropDonwList.Enabled = false;
        }

        private static string GetEnumDescription<T>(T value)
        {

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();

        }

        private static void ConfigurarTextoPresentacionVacio<T>(DropDownList dropDownList)
        {
            String glosaTextoPresentacion = "Seleccione ";
            List<DescriptionAttribute> titulo = ((DescriptionAttribute[])typeof(T).GetCustomAttributes(typeof(DescriptionAttribute), false)).ToList();
            if (titulo.Count > 0)
                glosaTextoPresentacion += titulo[0].Description;

            else
                glosaTextoPresentacion += typeof(T).Name;
            ListItem dummie = new ListItem(glosaTextoPresentacion, "");
            dropDownList.Items.Insert(0, dummie);
            dropDownList.SelectedValue = "";
        }

        public static int ObtenerValorSeleccionadoDropDownList(DropDownList dropDown, bool optimista, string mensaje)
        {
            if (string.IsNullOrEmpty(dropDown.SelectedValue))
            {
                if (optimista) return 0;
                else throw new ApplicationException(mensaje);
            }
            else
            {
                int valorEntero = 0;
                if (!Int32.TryParse(dropDown.SelectedValue, out valorEntero))
                {
                    if (optimista) return 0;
                    else throw new ApplicationException(mensaje);
                }
                else
                {
                    return valorEntero;
                }
            }
        }

        public static DateTime? ObtenerFechaSeleccionable(string p, string p_2, string p_3)
        {
            throw new NotImplementedException();
        }

        public static DateTime? ObtenerFechaSeleccionable(string anio, string mes, string dia, string mensajeEnError)
        {
            try
            {
                return new ManipuladorFecha().TextoAFechaNulable(anio, mes, dia);
            }
            catch (Exception)
            {
                throw new ActionableException(mensajeEnError);
            }
        }

    }
}
