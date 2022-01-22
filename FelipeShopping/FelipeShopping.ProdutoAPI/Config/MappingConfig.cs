using AutoMapper;
using FelipeShopping.ProdutoAPI.Data.ValueObjects;
using FelipeShopping.ProdutoAPI.Model;

namespace FelipeShopping.ProdutoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoVO, Produto>();
                config.CreateMap<Produto, ProdutoVO>();
            });
            return mappingConfig;
        }
    }
}
