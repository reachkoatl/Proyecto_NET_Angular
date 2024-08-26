using RodrigoTiendaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoTiendaBack.Business
{
    public interface ITiendaService
    {
        Task<IEnumerable<Tienda>> GetAllTiendas();
        Task<Tienda> GetTiendaById(int id);
        Task<Tienda> AddTienda(Tienda tienda);
        Task<Tienda> UpdateTienda(Tienda tienda);
        Task<bool> DeleteTienda(int id);
    }
}
