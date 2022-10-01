using AutoMapper;
using Data.Models.DataBase;
using Dominio.DTOs;

namespace Dominio.Utils.Mapper
{
    internal class MapperDomainProfile : Profile
    {
        public MapperDomainProfile()
        {
            CreateMap<Modulo, ModuloDto>();
            CreateMap<ModuloDto, Modulo>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();
        }
    }
}
