using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioClientes
    {
        void Borrar(int clienteId, SqlConnection conn, SqlTransaction? tran = null);

        void Agregar(Cliente cliente, SqlConnection conn, SqlTransaction? tran = null);

        bool Existe(Cliente cliente, SqlConnection conn, SqlTransaction? tran = null);

        void Editar(Cliente cliente, SqlConnection conn, SqlTransaction tran);
        Cliente? GetClientePorId(int clienteId, SqlConnection conn);
        List<ClienteListDto>? GetLista(SqlConnection conn);
    }
}
