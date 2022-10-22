using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dto.Core;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_CATALOGOPARAMETROS
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDCATALOGOPARAMETRO { get; set; }
        public String NOMBRE { get; set; }
        public int TIPOESTADOENTIDAD { get; set; }
        public String CODIGO { get; set; }


        #region Metodos DaoCW_CATALOGOPARAMETROS
        public int Create(CatalogoParametro daoObject)
        {
            try
            {
                DaoCW_CATALOGOPARAMETROS daocw_catalogoparametros = DaoCW_CATALOGOPARAMETROSTypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_CATALOGOPARAMETROS.CreateDaoCW_CATALOGOPARAMETROS", daocw_catalogoparametros);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_catalogoparametros", ex);
            }

        }

        public CatalogoParametro Find(int id)
        {
            try
            {
                DaoCW_CATALOGOPARAMETROS resultado = Instance().QueryForObject<DaoCW_CATALOGOPARAMETROS>("DaoCW_CATALOGOPARAMETROS.Find", id);
                CatalogoParametro resultadoCasteado = DaoCW_CATALOGOPARAMETROSTypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CATALOGOPARAMETROS", ex);
            }
        }

        public List<CatalogoParametro> FindAll()
        {
            try
            {
                return DaoCW_CATALOGOPARAMETROSTypeHandler.CastList(Instance().QueryForList<DaoCW_CATALOGOPARAMETROS>("DaoCW_CATALOGOPARAMETROS.FindAllDaoCW_CATALOGOPARAMETROS", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_CATALOGOPARAMETROS", ex);
            }
        }

        public void Update(CatalogoParametro daoObject)
        {
            try
            {
                DaoCW_CATALOGOPARAMETROS daocw_catalogoparametros = DaoCW_CATALOGOPARAMETROSTypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_CATALOGOPARAMETROS.UpdateDaoCW_CATALOGOPARAMETROS", daocw_catalogoparametros);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_catalogoparametros", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_CATALOGOPARAMETROS.DeleteDaoCW_CATALOGOPARAMETROS", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_catalogoparametros", ex);

            }
        }

        #endregion

    }
}
