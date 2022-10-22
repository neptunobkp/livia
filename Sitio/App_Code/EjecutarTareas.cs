using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pulse.Contactador.BusinessLogic.EnvioCorreo;
using Pulse.Contactador.BusinessLogic.Operaciones;
using Pulse.Contactador.Dto;
using Pulse.Contactador.BusinessLogic;
using Pulse.Contactador.Dao.DaoDataModel;
using System.Text;
using Pulse.Utils;

/// <summary>
/// Summary description for EjecutarTareas
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EjecutarTareas : System.Web.Services.WebService
{


    [WebMethod]
    public void EjecutarTareasPendientes()
    {
        try
        {
            DaoTransacciones transaccion = new DaoTransacciones();
            StringBuilder mensaje = new StringBuilder();
            List<Campania> campanias = new GestionarTareasPendientes().ValidarTareasPendientes();
            mensaje.AppendLine(String.Format("el numero de campanias a ejecutar es: {0}", campanias.Count()));
            int contador = 0;
            foreach (var cadaCampania in campanias)
            {
                try
                {
                    mensaje.AppendLine(String.Format("***************************************************************"));
                    mensaje.AppendLine(String.Format("*******************Inicia Transaccion**************************"));
                    mensaje.AppendLine(String.Format("***************************************************************"));
                    transaccion.IniciarTransaccion();
                    mensaje.AppendLine(String.Format("Inicia busqueda control envio correo"));
                    cadaCampania.ControladorEnvioCorreo = new GestionarControladorEnvioCorreo().ObtenerControladorEnvioCorreoPorControladorEnvioCorreoId(cadaCampania.ControladorEnvioCorreo.Id);
                    mensaje.AppendLine(String.Format("Termina busqueda control envio correo"));
                    mensaje.AppendLine(String.Format("Inicia ejecucion campania"));
                    new GestionadorEjecucionPlanCampania().EjecutarCampania(cadaCampania);
                    mensaje.AppendLine(String.Format("Termina ejecucion campania"));
                    mensaje.AppendLine(String.Format("Inicia Agregar estado campania"));
                    new GestionarEstadoCampanias().AgregarEstadoCampania(cadaCampania);
                    mensaje.AppendLine(String.Format("Termina Agregar estado campania"));
                    transaccion.ComprometerTransaccion();
                    contador++;
                    mensaje.AppendLine(String.Format("***************************************************************"));
                    mensaje.AppendLine(String.Format("****************Termina Transaccion numero {0} ****************************", contador));
                    mensaje.AppendLine(String.Format("***************************************************************"));
                    ManejadorArchivos.CrearArchivo(Server.MapPath("~/Bandeja/ArchivosDemonio/" + CadenaUtils.CompletarNombreArchivoFechaHora("TransaccionesOK") + ".txt"), mensaje.ToString());

                }
                catch (Exception ex)
                {
                    transaccion.DeshacerTransaccion();
                    mensaje.AppendLine(String.Format("Fracasa Transaccion"));
                    ManejadorArchivos.CrearArchivo(Server.MapPath("~/Bandeja/ArchivosDemonio/" + CadenaUtils.CompletarNombreArchivoFechaHora("Errortransaccion") + ".txt"), mensaje.ToString() + ex.Message);
                }
            }

        }
        catch (Exception ex)
        {
            ManejadorArchivos.CrearArchivo(Server.MapPath("~/Bandeja/ArchivosDemonio/" + CadenaUtils.CompletarNombreArchivoFechaHora("ErrorMetodo") + ".txt"), ex.Message);

        }
    }
}

