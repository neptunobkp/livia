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
    public class DaoCW_ENCUESTATypeHandler
    {
        public static Encuesta CastToDto(DaoCW_ENCUESTA cw_encuesta)
        {
            Encuesta dtoObject = new Encuesta() { PlantillaEncuesta = new Plantilla(), UsuarioModificador = new Usuario(), UsuarioCreador = new Usuario() };
            dtoObject.Id = cw_encuesta.IDENCUESTA;
            dtoObject.PlantillaEncuesta.Id = cw_encuesta.IDPLANTILLAENCUESTA;
            dtoObject.NumeroPaginas = cw_encuesta.NUMEROPAGINAS;
            dtoObject.Titulo = cw_encuesta.TITULO;
            dtoObject.Introduccion = cw_encuesta.INTRODUCCION;
            dtoObject.MensajePiePagina = cw_encuesta.MENSAJEPIEPAGINA;
            dtoObject.DescripcionPiePagina = cw_encuesta.DESCRIPCIONPIEPAGINA;
            dtoObject.FechaInicioVigencia = cw_encuesta.FECHAINICIOVIGENCIA;
            dtoObject.FechaTerminoVigencia = cw_encuesta.FECHATERMINOVIGENCIA;
            dtoObject.CuotaLimiteEncuesta = cw_encuesta.CUOTALIMITEENCUESTA;
            dtoObject.PrimeraPaginaContenidaEnPresentacion = Convert.ToBoolean(cw_encuesta.PRIMERAPAGINACONTENIDA);
            dtoObject.UsuarioCreador.Id = cw_encuesta.USUARIOCREADOR;
            dtoObject.FechaCreacion = cw_encuesta.FECHACREACION;
            dtoObject.UsuarioModificador.Id = cw_encuesta.USUARIOMODIFICADOR;
            dtoObject.FechaModificacion = cw_encuesta.FECHAULTIMAMODIFICACION;
            dtoObject.IdentificadorPropietarioAplicacion = cw_encuesta.IDPROPIETARIO;
            dtoObject.TipoPropietario = (TiposPropietario)cw_encuesta.TIPOPROPIETARIO;
            dtoObject.TipoServicio = cw_encuesta.TIPOSERVICIO;
            return dtoObject;
        }

        public static DaoCW_ENCUESTA CastToDao(Encuesta dtoObject)
        {
            DaoCW_ENCUESTA daoObject = new DaoCW_ENCUESTA();

            daoObject.IDENCUESTA = dtoObject.Id;
            daoObject.IDPLANTILLAENCUESTA = dtoObject.PlantillaEncuesta.Id;
            daoObject.NUMEROPAGINAS = dtoObject.NumeroPaginas;
            daoObject.TITULO = dtoObject.Titulo;
            daoObject.INTRODUCCION = dtoObject.Introduccion;
            daoObject.MENSAJEPIEPAGINA = dtoObject.MensajePiePagina;
            daoObject.DESCRIPCIONPIEPAGINA = dtoObject.DescripcionPiePagina;
            daoObject.FECHAINICIOVIGENCIA = dtoObject.FechaInicioVigencia;
            daoObject.FECHATERMINOVIGENCIA = dtoObject.FechaTerminoVigencia;
            daoObject.CUOTALIMITEENCUESTA = dtoObject.CuotaLimiteEncuesta;
            daoObject.PRIMERAPAGINACONTENIDA = Convert.ToInt32(dtoObject.PrimeraPaginaContenidaEnPresentacion);
            daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHAULTIMAMODIFICACION = dtoObject.FechaModificacion;
            daoObject.IDPROPIETARIO = dtoObject.IdentificadorPropietarioAplicacion;
            daoObject.TIPOPROPIETARIO = (int)dtoObject.TipoPropietario;
            daoObject.TIPOSERVICIO = dtoObject.TipoServicio;
            return daoObject;
        }

        public static List<Encuesta> CastList(IList<DaoCW_ENCUESTA> listOfDaocw_encuesta)
        {
            List<Encuesta> resultado = new List<Encuesta>();
            foreach (var cadacw_encuesta in listOfDaocw_encuesta)
            {
                resultado.Add(CastToDto(cadacw_encuesta));
            }
            return resultado;
        }
    }
}
