using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarItemCarpetaEncuesta
    {
        DaoItemCarpetaEncuesta _daoItemCarpetaEncuesta;
        public GestionarItemCarpetaEncuesta()
        {
            _daoItemCarpetaEncuesta = new DaoItemCarpetaEncuesta();
        }
        public List<ItemCarpetaEncuesta> ObtenerItemCarpetaEncuestaPorCarpeta(int carpetaId)
        {
            try
            {
                return _daoItemCarpetaEncuesta.FindByCarpetaId(carpetaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al obtener Items Carpeta Encuesta" + ex.Message, ex);
            }
        }
        public void AgregarItemCarpetaEncuesta(ItemCarpetaEncuesta itemCarpetaEncuesta)
        {
            try
            {
                _daoItemCarpetaEncuesta.Create(itemCarpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear Item Carpeta Encuesta" + ex.Message, ex);
            }
        }
        public void ActualizarItemCarpetaEncuesta(ItemCarpetaEncuesta itemCarpetaEncuesta)
        {
            try
            {
                _daoItemCarpetaEncuesta.Update(itemCarpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al actualizar Item Carpeta Encuesta" + ex.Message, ex);
            }
        }

        public ItemCarpetaEncuesta ObtenerItemCarpeta(int itemCarpetaEncuestaId)
        {
            try
            {
                return _daoItemCarpetaEncuesta.FindItemCarpetaEncuesta(itemCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al buscar Item Carpeta Encuesta" + ex.Message, ex);
            }
        }

        public void EliminarItemCarpetaEncuesta(int itemCarpetaEncuestaId)
        {
            try
            {
                _daoItemCarpetaEncuesta.Delete(itemCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al eliminar Item Carpeta Encuesta" + ex.Message, ex);
            }
        }

        public void EliminarItemsCarpetaEncuestaPorGrupoYCarpeta(string grupoId, string carpetaId)
        {
            try
            {
                _daoItemCarpetaEncuesta.DeleteByGrupoYCarpeta(grupoId, carpetaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al eliminar Item Carpeta Encuesta" + ex.Message, ex);
            }
        }
    }
}
