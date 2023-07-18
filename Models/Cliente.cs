using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Idcliente { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Dni { get; set; }
        public string Sexo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int Telefono { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
