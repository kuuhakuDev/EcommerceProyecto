using System;
using System.Collections.Generic;

namespace Data.Models.DataBase
{
    public partial class Permiso
    {
        public Permiso()
        {
            Accesos = new HashSet<Acceso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Method { get; set; } = null!;

        public virtual ICollection<Acceso> Accesos { get; set; }
    }
}
