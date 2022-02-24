using FelipeShopping.CarrinhoAPI.Model.Base;

namespace FelipeShopping.CarrinhoAPI.Config.ValueOjects
{
    public class CarrinhoHeaderVO : BaseEntity
    {
        public string UsuarioId { get; set; }

        public string CodigoCupom { get; set; }
    }
}
