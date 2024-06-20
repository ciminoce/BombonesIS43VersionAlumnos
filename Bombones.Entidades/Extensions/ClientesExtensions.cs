using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class ClientesExtensions
    {
        public static ClienteListDto ToClienteListDto(Cliente cliente)
        {
            return new ClienteListDto
            {
                ClienteId = cliente.ClienteId,
                Nombres = cliente.Nombres,
                Apellido = cliente.Apellido,
                Documento = cliente.Documento,
            };
        }
    }
}
