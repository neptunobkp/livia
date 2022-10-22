using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionarGruposEncuestado
    {
        DaoGrupoEncuestado _daoGrupoEncuestado;

        public GestionarGruposEncuestado()
        {
            _daoGrupoEncuestado = new DaoGrupoEncuestado();
        }

        public void AgregarGrupoEncuestado(Pulse.Contactador.Dto.GrupoEncuestado grupoEncuestado)
        {
            try
            {
                grupoEncuestado.Estado = 1;
                _daoGrupoEncuestado.Create(grupoEncuestado);
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al crear el grupo" + ex.Message, ex);
            }
        }

        public List<GrupoEncuestado> ObtenerGrupos()
        {
            try
            {
                return _daoGrupoEncuestado.FindAll();
            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error al buscar los grupos" + ex.Message, ex);
            }
        }
    }
}
