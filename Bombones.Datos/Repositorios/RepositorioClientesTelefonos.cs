using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientesTelefonos : IRepositorioClientesTelefonos
    {
        public void Agregar(ClienteTelefono clienteTelefono, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO ClientesTelefonos (ClienteId, TelefonoId, TipoTelefonoId)
            VALUES (@ClienteId, @TelefonoId, @TipoTelefonoId);
        ";
            conn.Execute(query, clienteTelefono, tran);
        }

        public void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM ClientesTelefonos WHERE ClienteId = @ClienteId";
            conn.Execute(query, new { ClienteId = clienteId }, tran);
        }

        public List<ClienteTelefono> GetTelefonosPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM ClientesTelefonos WHERE ClienteId = @ClienteId";
            return conn.Query<ClienteTelefono>(query, new { ClienteId = clienteId }, tran).ToList();
        }
    }
}
