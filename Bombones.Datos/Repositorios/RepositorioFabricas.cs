using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioFabricas : IRepositorioFabricas
    {
        public RepositorioFabricas()
        {
             
        }

        public void Agregar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Fabricas 
                (NombreFabrica, PaisId, ProvinciaEstadoId, CiudadId) 
                VALUES (@NombreCiudad, @PaisId, @ProvinciaEstadoId, @Ciudadid); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, fabrica,tran);
            if (primaryKey > 0)
            {
                fabrica.CiudadId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Fabrica");
        }

        public void Borrar(int fabricaId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM Fabricas 
                WHERE FabricaId=@FabricaId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { fabricaId },tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar la fabrica");
            }
        }

        public void Editar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Fabricas
            SET NombreCiudad=@NombreCiudad,
                PaisId=@PaisId,
                ProvinciaEstadoId=@ProvinciaEstadoId
                CiudadId=@CiudadId WHERE FabricaId=@FabricaId";
            int registrosAfectados = conn.Execute(updateQuery, fabrica,tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar fabrica");
            }

        }

        public bool EstaRelacionado(int fabricaId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Bombones 
                WHERE FabricaId=@FabricaId";
            return conn.QuerySingle<int>
                (selectQuery, new { fabricaId }) > 0;
        }

        public bool Existe(Fabrica fabrica, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Fabricas ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = fabrica.CiudadId == 0 ?
                " WHERE NombreFabrica=@NombreFabrica " :
                " WHERE NombreFabrica=@NombreFabrica " +
                "AND FabricaId<>@FabricaId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, fabrica) > 0;
        }

        public Fabrica? GetFabricaPorId(int fabricaId, SqlConnection conn)
        {
            string selectQuery = @"SELECT FabricaId, NombreFabrica, 
                PaisId, ProvinciaEstadoId, CiudadId FROM Fabricas 
                WHERE FabricaId=@FabricaId";
            return conn.QuerySingleOrDefault<Fabrica>(
                selectQuery, new {@FabricaId= fabricaId });
        }

        public List<FabricaListDto> GetLista(SqlConnection conn, SqlTransaction? tran=null)
        {
            string selectQuery = @"SELECT f.FabricaId, f.NombreFabrica,
                f.Direccion, p.NombrePais, pe.NombreProvinciaEstado, 
                c.NombreCiudad FROM Fabricas f
                INNER JOIN Paises p ON f.PaisId=p.PaisId INNER JOIN 
                ProvinciasEstados pe ON f.ProvinciaEstadoId=pe.ProvinciaEstadoId 
                INNER JOIN Ciudades c ON  f.CiudadId=c.CiudadId";
            return conn.Query<FabricaListDto>(selectQuery).ToList();
        }
    }
}
