using Data.Models.DataBase;
using Data.Models.Repository;
using Dominio.DTOs;
using Dominio.Utils;

namespace Dominio.Modulos
{
    public class RolService : GeneralService<Rol, RolDto>, IModuloService<RolDto>
    {
        public RolService(IRepository repository) : base(repository) { }
    }
}
