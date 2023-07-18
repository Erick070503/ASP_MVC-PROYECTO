using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Idcategoria { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
