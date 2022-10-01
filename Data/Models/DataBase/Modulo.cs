using System;
using System.Collections.Generic;

namespace Data.Models.DataBase
{
    public partial class Modulo
    {
        public Modulo()
        {
            Accesos = new HashSet<Acceso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Acceso> Accesos { get; set; }
    }
}
