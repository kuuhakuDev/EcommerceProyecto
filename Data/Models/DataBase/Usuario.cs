using System;
using System.Collections.Generic;

namespace Data.Models.DataBase
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RolId { get; set; }
        public string Password { get; set; } = null!;
        public string? Token { get; set; }

        public virtual Rol Rol { get; set; } = null!;
    }
}
