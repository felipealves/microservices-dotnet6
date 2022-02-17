namespace FelipeShopping.CarrinhoAPI.Model
{
    public class Carrinho
    {
        public CarrinhoHeader CarrinhoHeader { get; set; }

        public IEnumerable<CarrinhoDetail> CarrinhoDetails { get; set; }
    }
}
