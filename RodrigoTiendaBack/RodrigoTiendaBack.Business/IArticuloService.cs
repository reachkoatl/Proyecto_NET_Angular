using RodrigoTiendaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoTiendaBack.Business
{
    public interface IArticuloService
    {
        Task<IEnumerable<Articulo>> GetAllArticulos();
        Task<Articulo> GetArticuloById(int id);
        Task<Articulo> AddArticulo(Articulo articulo);
        Task<Articulo> UpdateArticulo(Articulo articulo);
        Task<bool> DeleteArticulo(int id);
    }
}
