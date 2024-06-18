using Bombones.Datos.Interfaces;
using Bombones.Datos.Repositorios;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeNueces : IServiciosTiposDeNueces
    {
        private readonly IRepositorioTiposDeNueces _repositorio;
        private readonly string? _cadena;
        public ServiciosTiposDeNueces(IRepositorioTiposDeNueces repositorio, string? cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public List<TipoDeNuez> GetLista()
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio.GetLista(conn);

            }
        }
        public bool EstaRelacionado(int tipoId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio.EstaRelacionado(tipoId, conn);

            }
        }
        public bool Existe(TipoDeNuez tipo)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio.Existe(tipo, conn);

            }
        }
        public void Borrar(int tipoDeNuezId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    _repositorio.Borrar(tipoDeNuezId, conn, tran);

                }
            }
        }
        public void Guardar(TipoDeNuez tipoDeNuez)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (tipoDeNuez.TipoDeNuezId == 0)
                        {
                            _repositorio.Agregar(tipoDeNuez, conn, tran);
                        }
                        else
                        {
                            _repositorio.Editar(tipoDeNuez, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
