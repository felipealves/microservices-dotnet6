using FelipeShopping.CarrinhoAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeShopping.CarrinhoAPI.Model
{
    [Table("carrinho_detail")]
    public class CarrinhoDetail : BaseEntity
    {
        public long CarrinhoHeaderId { get; set; }

        [ForeignKey("CarrinhoHeaderId")]
        public virtual CarrinhoHeader CarrinhoHeader { get; set; }


        public long ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }



        [Column("Contador")]
        public int Contador { get; set; }
    }
}
