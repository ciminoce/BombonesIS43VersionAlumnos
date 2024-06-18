using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosPaises
    {
        void Borrar(int paisId);
        bool EstaRelacionado(int paisId);
        bool Existe(Pais pais);
        List<Pais>? GetLista();
        void Guardar(Pais pais);
        Pais? GetPaisPorId(int paisId);
        int GetCantidad();
    }
}