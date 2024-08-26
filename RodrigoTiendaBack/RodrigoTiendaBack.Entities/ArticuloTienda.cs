using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoTiendaBack.Entities
{
    public class ArticuloTienda
    {
        public int ArticuloID { get; set; }
        public Articulo Articulo { get; set; }
        public int TiendaID { get; set; }
        public Tienda Tienda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
