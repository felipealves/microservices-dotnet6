using AutoMapper;
using FelipeShopping.CarrinhoAPI.Config.ValueOjects;
using FelipeShopping.CarrinhoAPI.Model;

namespace FelipeShopping.CarrinhoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoVO, Produto>().ReverseMap();
                config.CreateMap<CarrinhoHeaderVO, CarrinhoHeader>().ReverseMap();
                config.CreateMap<CarrinhoDetailVO, CarrinhoDetail>().ReverseMap();
                config.CreateMap<CarrinhoVO, Carrinho>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
