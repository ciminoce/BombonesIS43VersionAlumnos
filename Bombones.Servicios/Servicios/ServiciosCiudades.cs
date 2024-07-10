using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades? _repositorio;
        private readonly string? _cadena;

        public ServiciosCiudades(IRepositorioCiudades? repositorio,
            string? cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public void Borrar(int ciudadId)
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
                        _repositorio?.Borrar(ciudadId, conn, tran);
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

        public bool EstaRelacionado(int ciudadId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.EstaRelacionado(ciudadId, conn) ?? true;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.Existe(ciudad, conn) ?? true;
            }
        }

        public int GetCantidad(Pais? paisSeleccionado = null, ProvinciaEstado? provSeleccionada = null)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn=new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetCantidad(conn, paisSeleccionado, provSeleccionada);
            }
        }

        public Ciudad? GetCiudadPorId(int ciudadId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio?.GetCiudadPorId(ciudadId, conn);
            }
        }

        public List<CiudadListDto> GetLista(int? currentPage, int? pageSize)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetLista(conn, currentPage, pageSize);
            }
        }

        public List<Ciudad>? GetListaCombo(Pais paisSeleccionado, ProvinciaEstado provinciaEstado)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.GetListaCombo(conn, paisSeleccionado, provinciaEstado);
            }
        }

        public int GetPaginaPorRegistro(string nombreCiudad, int pageSize)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetPaginaPorRegistro(conn, nombreCiudad, pageSize);
            }

        }

        public void Guardar(Ciudad ciudad)
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
                        if (ciudad.CiudadId == 0)
                        {
                            _repositorio?.Agregar(ciudad, conn, tran);
                        }
                        else
                        {
                            _repositorio?.Editar(ciudad, conn, tran);
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
    }
}
