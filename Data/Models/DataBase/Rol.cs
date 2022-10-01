using System;
using System.Collections.Generic;

namespace Data.Models.DataBase
{
    public partial class Rol
    {
        public Rol()
        {
            Accesos = new HashSet<Acceso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Acceso> Accesos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
