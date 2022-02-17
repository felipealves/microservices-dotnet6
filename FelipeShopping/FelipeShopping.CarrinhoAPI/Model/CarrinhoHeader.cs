using FelipeShopping.CarrinhoAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelipeShopping.CarrinhoAPI.Model
{
    [Table("carrinho_header")]
    public class CarrinhoHeader : BaseEntity
    {
        [Column("usuario_id")]
        public string UsuarioId { get; set; }

        [Column("codigo_cupom")]
        public string CodigoCupom { get; set; }
    }
}
