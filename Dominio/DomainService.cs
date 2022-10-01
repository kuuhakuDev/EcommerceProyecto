using Data;
using Data.Models.DataBase;
using Data.Models.Repository;
using Dominio.Modulos;
using Dominio.Utils;
using Microsoft.EntityFrameworkCore;

namespace Dominio
{
    public class DomainService : IService
    {
        private readonly IRepository _repository;

        public DomainService(string connectionString)
        {
            _repository = new MainContext(new DbContextOptionsBuilder<TiendaOnlineContext>().UseSqlServer(connectionString).Options);
        }

        public DomainService(IRepository reposiroty)
        {
            _repository = reposiroty;
        }

        public ModuloService Modulo => new ModuloService(_repository);
        public UsuarioService Usuario => new UsuarioService(_repository);
        public RolService Rol => new RolService(_repository);

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}