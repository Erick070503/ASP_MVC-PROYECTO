using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Detalleventa
    {
        public int Idnumdocumento { get; set; }
        public string Serie { get; set; } = null!;
        public int Idproducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Venta IdnumdocumentoNavigation { get; set; } = null!;
        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
