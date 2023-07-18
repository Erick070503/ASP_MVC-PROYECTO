using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public int Contraseña { get; set; }
        public string TipoUsuario { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
