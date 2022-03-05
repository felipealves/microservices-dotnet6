namespace FelipeShopping.Web.Models
{
    public class CarrinhoHeaderViewModel
    {
        public long Id { get; set; }
        public string UsuarioId { get; set; }

        public string CodigoCupom { get; set; }

        public double ValorCompra { get; set; }
    }
}
