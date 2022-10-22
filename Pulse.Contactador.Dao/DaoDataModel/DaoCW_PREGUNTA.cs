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
    public class DaoCW_PREGUNTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDPREGUNTA { get; set; }
        public String GLOSAPREGUNTA { get; set; }
        public String NOTAADICIONALPREGUNTA { get; set; }
        public String NOTAADICIONALFINALPREGUNTA { get; set; }
        public int TIPOPREGUNTA { get; set; }
        public String CODIGOIDENTIFICADOR { get; set; }
        public int OTRAOPCION { get; set; }
        public int PRESENTARALEATORIAMENTE { get; set; }
        public int CANTIDADCOLUMNASPRESENTACION { get; set; }
        public int LIMITEMAXIMOSELECCIONABLES { get; set; }
        public int LIMITEMINIMOSELECCIONABLES { get; set; }
        public int PRESENTARENCOMBOBOX { get; set; }
        public int PRESENTARHORIZONTAL { get; set; }
        public int IDPAGINA { get; set; }
        public int NUMEROPAGINA { get; set; }
        public int OBLIGATORIO { get; set; }
        public String CATEGORIAPREGUNTA { get; set; }


        #region Metodos DaoCW_PREGUNTA
        public int Create(Pregunta daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_PREGUNTA.CreateDaoCW_PREGUNTA", daocw_pregunta);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_pregunta", ex);
            }
        }

        public int Create(PreguntaOpcionUnica daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_PREGUNTA.CreateDaoCW_PREGUNTA", daocw_pregunta);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_pregunta", ex);
            }
        }

        public int Create(PreguntaOpcionMultiple daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_PREGUNTA.CreateDaoCW_PREGUNTA", daocw_pregunta);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_pregunta", ex);
            }
        }

        public int Create(PreguntaMatriz daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_PREGUNTA.CreateDaoCW_PREGUNTA", daocw_pregunta);
                return Convert.ToInt32(resultado);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_pregunta", ex);
            }
        }

        public Pregunta Find<T>(int id)
        {
            try
            {
                DaoCW_PREGUNTA resultado = Instance().QueryForObject<DaoCW_PREGUNTA>("DaoCW_PREGUNTA.Find", id);
                Pregunta resultadoCasteado = DaoCW_PREGUNTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PREGUNTA", ex);
            }
        }

        public List<Pregunta> FindAll()
        {
            try
            {
                return DaoCW_PREGUNTATypeHandler.CastList(Instance().QueryForList<DaoCW_PREGUNTA>("DaoCW_PREGUNTA.FindAllDaoCW_PREGUNTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PREGUNTA", ex);
            }
        }

        public void Update(Pregunta daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PREGUNTA.UpdateDaoCW_PREGUNTA", daocw_pregunta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_pregunta", ex);
            }
        }

        public void Update(PreguntaOpcionUnica daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PREGUNTA.UpdateDaoCW_PREGUNTA", daocw_pregunta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_pregunta", ex);
            }
        }

        public void Update(PreguntaOpcionMultiple daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PREGUNTA.UpdateDaoCW_PREGUNTA", daocw_pregunta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_pregunta", ex);
            }
        }

        public void Update(PreguntaMatriz daoObject)
        {
            try
            {
                DaoCW_PREGUNTA daocw_pregunta = DaoCW_PREGUNTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PREGUNTA.UpdateDaoCW_PREGUNTA", daocw_pregunta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_pregunta", ex);
            }
        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_PREGUNTA.DeleteDaoCW_PREGUNTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_pregunta", ex);

            }

        }

        #endregion


        internal List<Pregunta> FindByPaginaId(int id)
        {
            try
            {
                return DaoCW_PREGUNTATypeHandler.CastList(Instance().QueryForList<DaoCW_PREGUNTA>("DaoCW_PREGUNTA.FindDaoCW_PREGUNTAByIDPAGINA", id));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PREGUNTA", ex);
            }
        }
    }
}
