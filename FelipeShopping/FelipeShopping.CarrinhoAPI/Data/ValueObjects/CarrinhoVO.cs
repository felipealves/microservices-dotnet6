namespace FelipeShopping.CarrinhoAPI.Config.ValueOjects
{
    public class CarrinhoVO
    {
        public CarrinhoHeaderVO CarrinhoHeader { get; set; }

        public IEnumerable<CarrinhoDetailVO> CarrinhoDetails { get; set; }
    }
}
