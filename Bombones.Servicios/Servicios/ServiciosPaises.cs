using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosPaises : IServiciosPaises
    {
        private readonly IRepositorioPaises _repositorio;
        private readonly string _cadena;
        public ServiciosPaises(IRepositorioPaises repositorio, string cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public void Borrar(int paisId)
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
                        _repositorio?.Borrar(paisId, conn, tran);
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

        public bool EstaRelacionado(int paisId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.EstaRelacionado(paisId, conn);
            }
        }

        public bool Existe(Pais pais)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.Existe(pais, conn);
            }
        }

        public Pais? GetPaisPorId(int paisId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio?.GetPaisPorId(paisId, conn);
            }
        }

        public List<Pais>? GetLista()
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.GetLista(conn);
            }
        }


        public void Guardar(Pais pais)
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
                        if (pais.PaisId == 0)
                        {
                            _repositorio?.Agregar(pais, conn, tran);
                        }
                        else
                        {
                            _repositorio?.Editar(pais, conn, tran);
                        }

                        tran.Commit();//guarda efectivamente
                    }
                    catch (Exception)
                    {
                        tran.Rollback();//tira todo pa tras!!!
                        throw;
                    }
                }
            }
        }


        public int GetCantidad()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetCantidad(conn);
            }

        }


    }
}
