using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RodrigoTiendaBack.Entities;

namespace RodrigoTiendaBack.Data
{
    public class RodrigoTiendaContext : DbContext
    {
        public RodrigoTiendaContext(DbContextOptions<RodrigoTiendaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<ArticuloTienda> ArticuloTiendas { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloTienda>()
                .HasKey(at => new { at.ArticuloID, at.TiendaID });

            modelBuilder.Entity<ClienteArticulo>()
                .HasKey(ca => new { ca.ClienteID, ca.ArticuloID });
        }
    }
}
