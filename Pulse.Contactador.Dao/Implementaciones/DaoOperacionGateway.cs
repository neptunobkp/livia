using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;
using IBatisNet.DataMapper;

namespace Pulse.Contactador.Dao.Implementaciones
{
    public class DaoOperacionGateway
    {
        #region Instacia SqlMapper
        SqlMapper _mapper;
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        DaoCW_USUARIOEXTERNO _daoUsuario;
        public DaoOperacionGateway()
        {
            _daoUsuario = new DaoCW_USUARIOEXTERNO();
        }

        public Usuario FindUsuarioByNombreIngreso(String nombreIngreso)
        {
            return _daoUsuario.FindByNombreIngreso(nombreIngreso.ToUpper());
        }

        public void AgregarCadenaConexion(CadenaConexion cadenaConexion)
        {
            Instance().Insert("DaoCW_Conexion.Create", cadenaConexion);
        }

        public IList<CadenaConexion> FindAllCadenasConexion()
        {
            return Instance().QueryForList<CadenaConexion>("DaoCW_Conexion.FindAll", null);
        }

        public CadenaConexion FindCadenaConexion(int cadenaConexionId)
        {
            return Instance().QueryForObject<CadenaConexion>("DaoCW_Conexion.Find", cadenaConexionId);
        }
    }
}
