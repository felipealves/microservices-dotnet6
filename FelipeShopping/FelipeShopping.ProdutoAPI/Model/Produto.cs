using FelipeShopping.ProdutoAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeShopping.ProdutoAPI.Model
{
    [Table("produto")]
    public class Produto: BaseEntity
    {
        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("valor")]
        [Required]
        [Range(1,10000)]
        public decimal Valor { get; set; }

        [Column("descricao")]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("categoria_nome")]
        [StringLength(50)]
        public string CategoriaNome { get; set; }

        [Column("imagem_url")]
        [StringLength(300)]
        public string ImagemUrl { get; set; }
    }
}
