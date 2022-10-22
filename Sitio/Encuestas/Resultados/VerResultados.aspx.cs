using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;

public partial class Encuestas_Resultados_VerResultados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int encuestaId = Convert.ToInt32(Request.Params["encuestaId"]);

        Encuesta encuesta = new GestionadorEncuesta().ObtenerEncuesta(encuestaId);
        literalTituloEncuesta.Text = encuesta.Titulo;
        this.repeaterPaginas.DataSource = encuesta.Paginas;
        this.repeaterPaginas.DataBind();
    }

    public int numeroRespuestas()
    {
        return Convert.ToInt32(Request.Params["respuestas"]);
    }
}
