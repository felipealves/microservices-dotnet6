namespace FelipeShopping.ProdutoAPI.Data.ValueObjects
{
    public class ProdutoVO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string CategoriaNome { get; set; }
        public string ImagemUrl { get; set; }
    }
}
