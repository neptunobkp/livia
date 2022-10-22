using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarRelacionCarpetaEncuesta
    {
        DaoRelacionCarpetaEncuesta _daoRelacionCarpetaEncuesta;
        public GestionarRelacionCarpetaEncuesta()
        {
            _daoRelacionCarpetaEncuesta = new DaoRelacionCarpetaEncuesta();
        }
        public List<RelacionCarpetaEncuesta> ObtenerRelacionCarpetaEncuestaPorCarpeta(int carpetaId)
        {
            try
            {
                return _daoRelacionCarpetaEncuesta.FindByCarpetaId(carpetaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al obtener Relacion Carpeta Encuesta" + ex.Message, ex);
            }
        }
        public void AgregarRelacionCarpetaEncuesta(RelacionCarpetaEncuesta relacionCarpetaEncuesta)
        {
            try
            {
                _daoRelacionCarpetaEncuesta.Create(relacionCarpetaEncuesta);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear Relacion Carpeta Encuesta" + ex.Message, ex);
            }
        }
        public void ActualizarRelacionCarpetaEncuesta(RelacionCarpetaEncuesta relacionCarpetaEncuestaId)
        {
            try
            {
                _daoRelacionCarpetaEncuesta.Update(relacionCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al actualizar Relacion Carpeta Encuesta" + ex.Message, ex);
            }
        }

        public RelacionCarpetaEncuesta ObtenerRelacionCarpeta(int relacionCarpetaEncuestaId)
        {
            try
            {
                return _daoRelacionCarpetaEncuesta.FindRelacionCarpetaEncuesta(relacionCarpetaEncuestaId);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al buscar Relacion Carpeta Encuesta" + ex.Message, ex);
            }
        }
    }
}
