using Data.Models.DataBase;
using Data.Models.Repository;
using Dominio.DTOs;
using Dominio.Utils;

namespace Dominio.Modulos
{
    public class UsuarioService : GeneralService<Usuario, UsuarioDto>, IModuloService<UsuarioDto>
    {
        public UsuarioService(IRepository repository) : base(repository) { }

        public override Task<UsuarioDto> Insert(UsuarioDto usuario)
        {
            usuario.Password = Crypto.GetHash(usuario.Password);
            return base.Insert(usuario);
        }

        public override async Task<UsuarioDto> Update(UsuarioDto value)
        {
            var user = _repository.Load<Usuario>().First(u => u.Id == value.Id);
            user.RolId = value.RolId;
            user.Nombre = value.Nombre;
            user.Email = value.Email;
            user.Password = Crypto.GetHash(value.Password);
            value.Password = user.Password;
            _repository.Update(user);
            await _repository.SaveChangesAsync();
            return value;
        }

        public async Task<string?> Login(string email, string pass)
        {
            var usuario = _repository.Load<Usuario>().First(u => u.Email == email);
            bool isSuccess = Crypto.VerifyPassword(pass, usuario.Password);
            if (isSuccess) 
            {
                usuario.Token = Guid.NewGuid().ToString();
                await _repository.SaveChangesAsync();
                return usuario.Token;
            }
            return null;
        }
        public async Task Logout(string token)
        {
            var usuario = _repository.Load<Usuario>().First(u => u.Token == token);
            usuario.Token = null;
            await _repository.SaveChangesAsync();
        }
    }
}
