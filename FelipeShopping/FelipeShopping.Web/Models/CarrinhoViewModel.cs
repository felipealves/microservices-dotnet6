namespace FelipeShopping.Web.Models
{
    public class CarrinhoViewModel
    {
        public CarrinhoHeaderViewModel CarrinhoHeader { get; set; }

        public IEnumerable<CarrinhoDetailViewModel> CarrinhoDetails { get; set; }
    }
}
