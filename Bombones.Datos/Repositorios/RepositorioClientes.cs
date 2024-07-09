using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes

    {
        public RepositorioClientes()
        {

        }

        public void Agregar(Cliente cliente, SqlConnection conn, SqlTransaction? tran)
        {
            string insertQuery = @"INSERT INTO Clientes 
                (Nombres, Apellido, Documento) 
                VALUES (@Nombres, @Apellido, @Documento); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, cliente, tran);
            if (primaryKey > 0)
            {
                cliente.ClienteId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar el cliente");
        }

        public void Borrar(int ClienteId, SqlConnection conn, SqlTransaction? tran)
        {
            var deleteQuery = @"DELETE FROM Clientes 
                WHERE ClienteId=@ClienteId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { ClienteId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el cliente");
            }
        }

        public bool Existe(Cliente cliente, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Clientes ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (cliente.ClienteId == 0)
                {
                    conditional = "WHERE Documento = @Documento";
                }
                else
                {
                    conditional = @"WHERE Documento = @Documento
                            AND ClienteId<>@ClienteId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, cliente) > 0;

            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el cliente");
            }
        }

        public void Editar(Cliente cliente, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Clientes
            SET Documento=@Documento,
                Apellido=@Apellido,
                Nombres=@Nombres
            WHERE ClienteId=@ClienteId";
            int registrosAfectados = conn.Execute(updateQuery, cliente, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el cliente");
            }
        }

        public Cliente? GetClientePorId(int clienteId, SqlConnection conn)
        {
            string selectQuery = @"SELECT ClienteId, Documento, Nombres, Apellido 
                FROM Clientes 
                WHERE ClienteId=@ClienteId";
            return conn.QuerySingleOrDefault<Cliente>(
                selectQuery, new { @ClienteId = clienteId });
        }

        public List<ClienteListDto> GetLista(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT ClienteId, Documento, 
                        Nombres, Apellido FROM Clientes";
            selectQuery += " ORDER BY ClienteId";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return conn.Query<ClienteListDto>(selectQuery).ToList();
        }

        public int GetCantidad(SqlConnection conn)
        {
            var selectQuery = "SELECT COUNT(*) FROM Clientes";
            List<string> conditions = new List<string>();

            return conn.ExecuteScalar<int>(selectQuery);

        }
    }
}
