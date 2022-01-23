namespace FelipeShopping.Web.Models
{
    public class ProdutoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string CategoriaNome { get; set; }
        public string ImagemUrl { get; set; }
    }
}
