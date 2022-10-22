using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_CONTROLADORENVIOTypeHandler
    {
        public static ControladorEnvioCorreo CastToDto(DaoCW_CONTROLADORENVIO cw_controladorenvio)
        {
            ControladorEnvioCorreo dtoObject = new ControladorEnvioCorreo()
            {
                MensajeCorreoUnico = new MensajeCorreoDestino(),
                ListaCorreosDestino = new ListaCorreoDestino(),
                ConfiguracionSalida = new ConfiguracionSalidaCorreo()
            };
            dtoObject.MensajeCorreoUnico.Id = cw_controladorenvio.IDMENSAJECORREOUNICO;
            dtoObject.Id = cw_controladorenvio.IDCONTROLADORENVIO;
            dtoObject.ListaCorreosDestino.Id = cw_controladorenvio.IDLISTACORREO;
            dtoObject.ConfiguracionSalida.Id = cw_controladorenvio.IDCONFIGURACIONSALIDA;
            dtoObject.TipoEnvioCorreo = (TiposEnvioCorreo)cw_controladorenvio.TIPOENVIOCORREO;
            return dtoObject;
        }

        public static DaoCW_CONTROLADORENVIO CastToDao(ControladorEnvioCorreo dtoObject)
        {
            DaoCW_CONTROLADORENVIO daoObject = new DaoCW_CONTROLADORENVIO();
            if (dtoObject.MensajeCorreoUnico != null) daoObject.IDMENSAJECORREOUNICO = dtoObject.MensajeCorreoUnico.Id;
            daoObject.IDCONTROLADORENVIO = dtoObject.Id;
            if (dtoObject.ListaCorreosDestino != null) daoObject.IDLISTACORREO = dtoObject.ListaCorreosDestino.Id;
            if (dtoObject.ConfiguracionSalida != null) daoObject.IDCONFIGURACIONSALIDA = dtoObject.ConfiguracionSalida.Id;
            daoObject.TIPOENVIOCORREO = (int)dtoObject.TipoEnvioCorreo;
            return daoObject;
        }

        public static List<ControladorEnvioCorreo> CastList(IList<DaoCW_CONTROLADORENVIO> listOfDaocw_controladorenvio)
        {
            List<ControladorEnvioCorreo> resultado = new List<ControladorEnvioCorreo>();
            foreach (var cadacw_controladorenvio in listOfDaocw_controladorenvio)
            {
                resultado.Add(CastToDto(cadacw_controladorenvio));
            }
            return resultado;
        }


    }
}
