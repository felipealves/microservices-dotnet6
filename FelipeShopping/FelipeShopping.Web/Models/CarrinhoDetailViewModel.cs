namespace FelipeShopping.Web.Models
{
    public class CarrinhoDetailViewModel
    {
        public long CarrinhoHeaderId { get; set; }

        public CarrinhoHeaderViewModel CarrinhoHeader { get; set; }

        public long ProdutoId { get; set; }

        public ProdutoViewModel Produto { get; set; }

        public int Contador { get; set; }
    }
}
