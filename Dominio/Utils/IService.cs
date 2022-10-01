using Dominio.Modulos;

namespace Dominio.Utils
{
    public interface IService : IDisposable
    {
        ModuloService Modulo { get; }
        UsuarioService Usuario { get; }
        RolService Rol { get; }
    }
}
