using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_CONTROLADORENVIO
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDMENSAJECORREOUNICO { get; set; }
        public int IDCONTROLADORENVIO { get; set; }
        public int IDLISTACORREO { get; set; }
        public int IDCONFIGURACIONSALIDA { get; set; }
        public int TIPOENVIOCORREO { get; set; }


        #region Metodos DaoCW_CONTROLADORENVIO
        public int Create(ControladorEnvioCorreo daoObject)
        {
            try
            {
                DaoCW_CONTROLADORENVIO daocw_controladorenvio = DaoCW_CONTROLADORENVIOTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_CONTROLADORENVIO.CreateDaoCW_CONTROLADORENVIO", daocw_controladorenvio);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_controladorenvio", ex);
            }

        }

        public ControladorEnvioCorreo Find(int id)
        {
            try
            {
                DaoCW_CONTROLADORENVIO resultado = Instance().QueryForObject<DaoCW_CONTROLADORENVIO>("DaoCW_CONTROLADORENVIO.FindDaoCW_CONTROLADORENVIO", id);
                ControladorEnvioCorreo resultadoCasteado = DaoCW_CONTROLADORENVIOTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CONTROLADORENVIO", ex);
            }
        }

        public List<ControladorEnvioCorreo> FindAll()
        {
            try
            {
                return DaoCW_CONTROLADORENVIOTypeHandler.CastList(Instance().QueryForList<DaoCW_CONTROLADORENVIO>("DaoCW_CONTROLADORENVIO.FindAllDaoCW_CONTROLADORENVIO", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CONTROLADORENVIO", ex);
            }
        }

        public void Update(ControladorEnvioCorreo daoObject)
        {
            try
            {
                DaoCW_CONTROLADORENVIO daocw_controladorenvio = DaoCW_CONTROLADORENVIOTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_CONTROLADORENVIO.UpdateDaoCW_CONTROLADORENVIO", daocw_controladorenvio);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_controladorenvio", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_CONTROLADORENVIO.DeleteDaoCW_CONTROLADORENVIO", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_controladorenvio", ex);

            }

        }

        #endregion

    }
}
