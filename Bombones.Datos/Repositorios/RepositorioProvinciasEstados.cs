using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProvinciasEstados : IRepositorioProvinciasEstados
    {
        public RepositorioProvinciasEstados()
        {
        }

        public void Agregar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran)
        {
            string insertQuery = @"INSERT INTO ProvinciasEstados 
                (NombreProvinciaEstado, PaisId) 
                VALUES (@NombreProvinciaEstado, @PaisId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, pe, tran);
            if (primaryKey > 0)
            {
                pe.ProvinciaEstadoId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Prov./Estado");
        }

        public void Borrar(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran)
        {
            var deleteQuery = @"DELETE FROM ProvinciasEstados 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            //TODO:Modificar este método
            int registrosAfectados = conn
                .Execute(deleteQuery, new { provinciaEstadoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar la prov/estado");
            }
        }

        public void Editar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran)
        {
            var updateQuery = @"UPDATE ProvinciasEstados 
            SET NombreProvinciaEstado=@NombreProvinciaEstado,
                PaisId=@PaisId
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            //TODO:Ver otra forma
            int registrosAfectados = conn.Execute(updateQuery, pe, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar prov/estado");
            }

        }

        public bool EstaRelacionado(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Ciudades 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            return conn.QuerySingle<int>
                (selectQuery, new { provinciaEstadoId }, tran) > 0;
        }

        public bool Existe(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM ProvinciasEstados ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = pe.ProvinciaEstadoId == 0 ?
                " WHERE NombreProvinciaEstado=@NombreProvinciaEstado AND PaisId=@PaisId" :
                " WHERE NombreProvinciaEstado=@NombreProvinciaEstado AND PaisId=@PaisId " +
                "AND ProvinciaEstadoId<>@ProvinciaEstadoId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, pe) > 0;
        }

        public int GetCantidad(SqlConnection conn, Pais? pais = null, SqlTransaction? tran = null)
        {
            var query = "SELECT COUNT(*) FROM ProvinciasEstados";
            if (pais != null)
            {
                query += " WHERE PaisId = @PaisId";
                return conn.ExecuteScalar<int>(query, new { PaisId = pais.PaisId });
            }
            return conn.ExecuteScalar<int>(query);
        }

        public List<ProvinciaEstadoListDto>? GetLista(
            SqlConnection conn,
            Orden? orden = Orden.Ninguno,
            Pais? pais = null,
            SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT pe.ProvinciaEstadoId, 
                        pe.NombreProvinciaEstado,
                        p.NombrePais 
                        FROM ProvinciasEstados pe
                        INNER JOIN Paises p ON pe.PaisId = p.PaisId";

            var conditions = new List<string>();
            if (pais != null)
            {
                conditions.Add("pe.PaisId = @PaisId");
            }

            var orderQuery = orden switch
            {
                Orden.PaisAZ => " ORDER BY p.NombrePais",
                Orden.PaisZA => " ORDER BY p.NombrePais DESC",
                Orden.ProvinciaEstadoAZ => " ORDER BY pe.NombreProvinciaEstado",
                Orden.ProvinciaEstadoZA => " ORDER BY pe.NombreProvinciaEstado DESC",
                _ => " ORDER BY pe.ProvinciaEstadoId"  // Default order
            };

            if (conditions.Any())
            {
                selectQuery += " WHERE " + string.Join(" AND ", conditions);
            }

            selectQuery += orderQuery;


            return conn.Query<ProvinciaEstadoListDto>(selectQuery, new { PaisId = pais?.PaisId }).ToList();
        }

        public List<ProvinciaEstado>? GetListaComboEstados(Pais pais, SqlConnection conn,
            SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT ProvinciaEstadoId,
                NombreProvinciaEstado, PaisId 
                FROM ProvinciasEstados 
                WHERE PaisId=@PaisId 
                ORDER BY NombreProvinciaEstado";
            return conn.Query<ProvinciaEstado>(selectQuery,
                new { @PaisId = pais.PaisId }).ToList();

        }

        public ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId, SqlConnection conn,
            SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT ProvinciaEstadoId, 
                NombreProvinciaEstado, PaisId FROM ProvinciasEstados 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";

            return conn.QueryFirstOrDefault<ProvinciaEstado>(selectQuery,
                new { provinciaEstadoId });
        }
    }
}
