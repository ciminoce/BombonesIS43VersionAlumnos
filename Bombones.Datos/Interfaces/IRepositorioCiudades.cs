using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Borrar(int ciudadId, SqlConnection conn, SqlTransaction tran);
        bool EstaRelacionado(int ciudadId, SqlConnection conn,
    SqlTransaction? tran = null);

        void Agregar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran);
        void Editar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran);
        bool Existe(Ciudad ciudad, SqlConnection conn,
            SqlTransaction? tran=null);
        List<CiudadListDto> GetLista(SqlConnection conn, 
            SqlTransaction? tran=null);
        Ciudad? GetCiudadPorId(int ciudadId, SqlConnection conn);
        List<Ciudad>? GetListaCombo(Pais paisSeleccionado, ProvinciaEstado provinciaEstado, SqlConnection conn);
    }
}
