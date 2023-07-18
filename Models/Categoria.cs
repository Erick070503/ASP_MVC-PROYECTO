using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idcategoria { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
