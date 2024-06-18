using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosProvinciasEstados
    {
        void Borrar(int provinciaEstadoId);
        bool EstaRelacionado(int provinciaEstadoId);
        bool Existe(ProvinciaEstado pe);
        
        List<ProvinciaEstadoListDto>? GetLista(Orden? orden = Orden.Ninguno,
            Pais ? paisSeleccionado=null);
        List<ProvinciaEstado>? GetListaComboEstados(Pais pais);
        ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId);
        void Guardar(ProvinciaEstado pe);
    }
}
