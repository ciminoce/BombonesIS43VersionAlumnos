using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProvinciasEstados : IServiciosProvinciasEstados
    {
        private readonly IRepositorioProvinciasEstados? _repositorio;
        private readonly string? _cadena;
        public ServiciosProvinciasEstados(IRepositorioProvinciasEstados repositorio,
            string cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

        }

        public void Borrar(int provinciaEstadoId)
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
                        _repositorio?.Borrar(provinciaEstadoId, conn, tran);
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

        public bool EstaRelacionado(int provinciaEstadoId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.EstaRelacionado(provinciaEstadoId, conn);

            }
        }

        public bool Existe(ProvinciaEstado pe)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.Existe(pe, conn);

            }
        }

        public int GetCantidad(Pais? filtroPais)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetCantidad(conn, filtroPais);

            }
        }



        public List<ProvinciaEstadoListDto>? GetLista(Orden? orden = Orden.Ninguno, Pais? paisSeleccionado = null)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.GetLista(conn, orden, paisSeleccionado
                    );

            }

        }

        public List<ProvinciaEstado>? GetListaComboEstados(Pais pais)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.GetListaComboEstados(pais, conn);

            }
        }

        public ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio?.GetProvinciaEstadoPorId(provinciaEstadoId, conn);

            }
        }

        public void Guardar(ProvinciaEstado pe)
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
                        if (pe.ProvinciaEstadoId == 0)
                        {
                            _repositorio?.Agregar(pe, conn, tran);
                        }
                        else
                        {
                            _repositorio?.Editar(pe, conn, tran);
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
