using Data.Models.DataBase;
using Data.Models.Repository;
using Dominio.DTOs;
using Dominio.Utils;

namespace Dominio.Modulos
{
    public class ModuloService : GeneralService<Modulo, ModuloDto>, IModuloService<ModuloDto>
    {
        public ModuloService(IRepository repository) : base(repository) { }
    }
}
