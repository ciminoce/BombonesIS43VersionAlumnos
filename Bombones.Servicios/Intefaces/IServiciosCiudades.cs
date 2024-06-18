using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosCiudades
    {
        void Borrar(int ciudadId);
        bool EstaRelacionado(int ciudadId);
        bool Existe(Ciudad ciudad);
        Ciudad? GetCiudadPorId(int ciudadId);
        List<CiudadListDto> GetLista();
        List<Ciudad>? GetListaCombo(Pais? paisSeleccionado, ProvinciaEstado provinciaEstado);
        void Guardar(Ciudad ciudad);
    }
}
