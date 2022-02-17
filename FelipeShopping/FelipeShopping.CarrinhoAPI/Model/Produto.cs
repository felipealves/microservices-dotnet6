using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeShopping.CarrinhoAPI.Model
{
    [Table("produto")]
    public class Produto
    {
        //DatabaseGenerated(DatabaseGeneratedOption.None) = Banco espera que passamos o valor do ID
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("valor")]
        [Required]
        [Range(1, 10000)]
        public decimal Valor { get; set; }

        [Column("descricao")]
        [StringLength(500)]
        public string? Descricao { get; set; }

        [Column("categoria_nome")]
        [StringLength(50)]
        public string? CategoriaNome { get; set; }

        [Column("imagem_url")]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
    }
}
