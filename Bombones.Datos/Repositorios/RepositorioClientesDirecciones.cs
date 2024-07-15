using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientesDirecciones : IRepositorioClientesDirecciones
    {
        public void Agregar(ClienteDireccion clienteDireccion, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
                INSERT INTO ClientesDirecciones (ClienteId, DireccionId, TipoDireccionId)
                VALUES (@ClienteId, @DireccionId, @TipoDireccionId);";
            conn.Execute(query, clienteDireccion, tran);
        }

        public void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM ClientesDirecciones WHERE ClienteId = @ClienteId";
            conn.Execute(query, new { ClienteId = clienteId }, tran);
        }

        public List<ClienteDireccion> GetDireccionesPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM ClientesDirecciones WHERE ClienteId = @ClienteId";
            return conn.Query<ClienteDireccion>(query, new { ClienteId = clienteId }, tran).ToList();
        }
    }
}
