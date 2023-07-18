using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Venta
    {
        public int Idnumdocumento { get; set; }
        public string Serie { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public int Idcliente { get; set; }
        public string Dni { get; set; } = null!;
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual Detalleventa Detalleventum { get; set; } = null!;
    }
}
