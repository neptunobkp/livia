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
    public class DaoCW_CAMPANIASTypeHandler
    {
        public static Campania CastToDto(DaoCW_CAMPANIAS cw_campanias)
        {
            Campania dtoObject = new Campania()
            {
                Encuesta = new Encuesta(),
                ControladorEnvioCorreo = new ControladorEnvioCorreo(),
                Motivo = new EntidadParametrizable(),
                UsuarioCreador = new Usuario(),
                UsuarioModificador = new Usuario()
            };
            dtoObject.Id = cw_campanias.IDCAMPANIA;
            dtoObject.Encuesta.Id = cw_campanias.IDENCUESTA;
            dtoObject.FechaEnvioEsperado = cw_campanias.FECHAENVIOESPERADO;
            dtoObject.ControladorEnvioCorreo.Id = cw_campanias.IDCONTROLADORENVIO;
            dtoObject.Motivo.Glosa = cw_campanias.GLOSAMOTIVOENVIO;
            //dtoObject.Motivo. = cw_campanias.VALORMOTIVOENVIO; TODO
            dtoObject.Nombre = cw_campanias.NOMBRE;
            dtoObject.IdentificadorPropietario = cw_campanias.IDPROPIETARIO;
            dtoObject.TipoPropietario = (TiposPropietario)cw_campanias.TIPOPROPIETARIO;
            dtoObject.UsuarioCreador.Id = cw_campanias.USUARIOCREADOR;
            dtoObject.UsuarioModificador.Id = cw_campanias.USUARIOMODIFICADOR;
            dtoObject.FechaCreacion = cw_campanias.FECHACREACION;
            dtoObject.FechaModificacion = cw_campanias.FECHAMODIFICACION;
            dtoObject.TipoPeriodoEjecucion = (TiposPeriodosEjecucion)cw_campanias.PERIODOEJECUCION;
            dtoObject.FechaTerminoEsperado = cw_campanias.FECHATERMINOESPERADO;
            //dtoObject.Encuesta. = cw_campanias.URLENCUESTA; TODO
            return dtoObject;
        }

        public static DaoCW_CAMPANIAS CastToDao(Campania dtoObject)
        {
            DaoCW_CAMPANIAS daoObject = new DaoCW_CAMPANIAS();
            daoObject.IDCAMPANIA = dtoObject.Id;
            if (dtoObject.Encuesta != null)
                daoObject.IDENCUESTA = dtoObject.Encuesta.Id;
            daoObject.FECHAENVIOESPERADO = dtoObject.FechaEnvioEsperado;
            daoObject.IDCONTROLADORENVIO = dtoObject.ControladorEnvioCorreo.Id;
            daoObject.GLOSAMOTIVOENVIO = dtoObject.Motivo.Glosa;
            //daoObject.VALORMOTIVOENVIO = dtoObject.Motivo.; TODO
            daoObject.NOMBRE = dtoObject.Nombre;
            daoObject.IDPROPIETARIO = dtoObject.IdentificadorPropietario;
            daoObject.TIPOPROPIETARIO = (int)dtoObject.TipoPropietario;
            daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.FECHAMODIFICACION = dtoObject.FechaModificacion;
            daoObject.FECHATERMINOESPERADO = dtoObject.FechaTerminoEsperado;
            daoObject.PERIODOEJECUCION = (int)dtoObject.TipoPeriodoEjecucion;
            //daoObject.URLENCUESTA = dtoObject.Encuesta.; TODO
            return daoObject;
        }

        public static List<Campania> CastList(IList<DaoCW_CAMPANIAS> listOfDaocw_campanias)
        {
            List<Campania> resultado = new List<Campania>();
            foreach (var cadacw_campanias in listOfDaocw_campanias)
            {
                resultado.Add(CastToDto(cadacw_campanias));
            }
            return resultado;
        }


    }
}
