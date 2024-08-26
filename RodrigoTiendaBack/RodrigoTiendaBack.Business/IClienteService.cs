using RodrigoTiendaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RodrigoTiendaBack.Business
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);

        Task<Cliente> AgregarAlCarrito(int clienteId, int articuloId);
        Task<Cliente> EliminarDelCarrito(int clienteId, int articuloId);
        Task<Cliente> ObtenerCarrito(int clienteId);

        Task AgregarArticuloAlCarrito(int clienteId, int articuloId);
        Task<bool> EliminarArticuloDelCarrito(int clienteId, int articuloId);
        
    }
}
