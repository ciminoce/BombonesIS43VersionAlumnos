﻿using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosClientes
    {
        void Borrar(int clienteId);
        bool EstaRelacionado(int clienteId);
        bool Existe(Cliente cliente);
        List<ClienteListDto> GetLista();
        void Guardar(Cliente cliente);
        Cliente? GetClientePorId(int clienteId);
    }
}
