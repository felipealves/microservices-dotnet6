using System.ComponentModel.DataAnnotations;

namespace FelipeShopping.Web.Models
{
    public class ProdutoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string CategoriaNome { get; set; }
        public string ImagemUrl { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringNome()
        {
            if (Nome.Length < 24)
                return Nome;

            return $"{Nome.Substring(0, 21)} ...";
        }

        public string SubstringDescricao()
        {
            if (Descricao.Length < 355)
                return Nome;

            return $"{Descricao.Substring(0, 352)} ...";
        }
    }
}
