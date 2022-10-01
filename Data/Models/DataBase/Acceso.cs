using System;
using System.Collections.Generic;

namespace Data.Models.DataBase
{
    public partial class Acceso
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int ModuloId { get; set; }
        public int PermisoId { get; set; }

        public virtual Modulo Modulo { get; set; } = null!;
        public virtual Permiso Permiso { get; set; } = null!;
        public virtual Rol Rol { get; set; } = null!;
    }
}
