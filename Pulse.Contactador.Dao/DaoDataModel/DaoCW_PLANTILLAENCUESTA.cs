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
    public class DaoCW_PLANTILLAENCUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDPLANTILLAENCUESTA { get; set; }
        public String PATHBANNER { get; set; }
        public int ALINEACIONLOGO { get; set; }
        public int ALINEACIONENCUESTA { get; set; }
        public String RUTAARCHIVOCSS { get; set; }
        public String BOTONSIGUIENTETEXTO { get; set; }
        public int BOTONSIGUIENTELARGO { get; set; }
        public int BOTONSIGUIENTEANCHO { get; set; }
        public String BOTONSIGUIENTEPATHIMAGEN { get; set; }
        public String BOTONVOLVERTEXTO { get; set; }
        public int BOTONVOLVERLARGO { get; set; }
        public int BOTONVOLVERANCHO { get; set; }
        public String BOTONVOLVERPATHIMAGEN { get; set; }
        public int BOTONGUARDARLARGO { get; set; }
        public int BOTONGUARDARANCHO { get; set; }
        public String BOTONGUARDARPATHIMAGEN { get; set; }
        public String BOTONSALIRTEXTO { get; set; }
        public int BOTONSALIRLARGO { get; set; }
        public int BOTONSALIRANCHO { get; set; }
        public String BOTONSALIRPATHIMAGEN { get; set; }
        public int IDPROPIETARIOAPP { get; set; }
        public int USUARIOCREADOR { get; set; }
        public DateTime FECHACREACION { get; set; }
        public int USUARIOMODIFICADOR { get; set; }
        public DateTime FECHAMODIFICACION { get; set; }
        public String TITULO { get; set; }
        public String DESCRIPCIONHTML { get; set; }
        public String PIEPAGINAHTML { get; set; }
        public String NOMBRECARPETAPLANTILLA { get; set; }

        #region Metodos DaoCW_PLANTILLAENCUESTA
        public int Create(Plantilla daoObject)
        {
            try
            {
                DaoCW_PLANTILLAENCUESTA daocw_plantillaencuesta = DaoCW_PLANTILLAENCUESTATypeHandler.CastToDao(daoObject);
                object resultado =  Instance().Insert("DaoCW_PLANTILLAENCUESTA.CreateDaoCW_PLANTILLAENCUESTA", daocw_plantillaencuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_plantillaencuesta", ex);
            }

        }

        public Plantilla Find(int id)
        {
            try
            {
                DaoCW_PLANTILLAENCUESTA resultado = Instance().QueryForObject<DaoCW_PLANTILLAENCUESTA>("DaoCW_PLANTILLAENCUESTA.FindDaoCW_PLANTILLAENCUESTA", id);
                Plantilla resultadoCasteado = DaoCW_PLANTILLAENCUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PLANTILLAENCUESTA", ex);
            }
        }

        public List<Plantilla> FindAll()
        {
            try
            {
                return DaoCW_PLANTILLAENCUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_PLANTILLAENCUESTA>("DaoCW_PLANTILLAENCUESTA.FindAllDaoCW_PLANTILLAENCUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_PLANTILLAENCUESTA", ex);
            }
        }

        public void Update(Plantilla daoObject)
        {
            try
            {
                DaoCW_PLANTILLAENCUESTA daocw_plantillaencuesta = DaoCW_PLANTILLAENCUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_PLANTILLAENCUESTA.UpdateDaoCW_PLANTILLAENCUESTA", daocw_plantillaencuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_plantillaencuesta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_PLANTILLAENCUESTA.DeleteDaoCW_PLANTILLAENCUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_plantillaencuesta", ex);
            }

        }

        #endregion

    }
}
