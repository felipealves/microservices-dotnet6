using FelipeShopping.CarrinhoAPI.Model.Base;

namespace FelipeShopping.CarrinhoAPI.Config.ValueOjects
{
    public class CarrinhoDetailVO : BaseEntity
    {
        public long CarrinhoHeaderId { get; set; }

        public CarrinhoHeaderVO CarrinhoHeader { get; set; }

        public long ProdutoId { get; set; }

        public ProdutoVO Produto { get; set; }

        public int Contador { get; set; }
    }
}
