using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes? _repositorio;
        private readonly string? _cadena;

        public ServiciosClientes(IRepositorioClientes? repositorio,
            string? cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public void Borrar(int clienteId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio?.Borrar(clienteId, conn, tran);
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

        public bool EstaRelacionado(int clienteId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Cliente cliente)
        {
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.Existe(cliente, conn);
            }
        }

        public List<ClienteListDto> GetLista(int? currentPage, int? pageSize)
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

        public Cliente? GetClientePorId(int clienteId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio?.GetClientePorId(clienteId, conn);
            }
        }

        public void Guardar(Cliente cliente)
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
                        if (cliente.ClienteId == 0)
                        {
                            _repositorio?.Agregar(cliente, conn, tran);
                        }
                        else
                        {
                            _repositorio?.Editar(cliente, conn, tran);
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
            if (_repositorio is null)
            {
                throw new ApplicationException("Dependencias no cargadas!!!");
            }
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetCantidad(conn);
            }

        }
    }
}
