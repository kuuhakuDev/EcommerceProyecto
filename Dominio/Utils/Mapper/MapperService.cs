using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

namespace Dominio.Utils.Mapper
{
    internal static class MapperService
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile(new MapperDomainProfile());  //mapping between Web and Business layer objects
            });

            return config;
        }
    }
}
