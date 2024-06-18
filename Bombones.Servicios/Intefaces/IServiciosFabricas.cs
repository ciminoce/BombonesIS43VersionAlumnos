using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosFabricas
    {
        void Borrar(int fabricaId);
        bool EstaRelacionado(int fabricaId);

        void Guardar(Fabrica fabrica);
        bool Existe(Fabrica fabrica);
        List<FabricaListDto> GetLista();
        Fabrica? GetFabricaPorId(int fabricaId);
    }
}
