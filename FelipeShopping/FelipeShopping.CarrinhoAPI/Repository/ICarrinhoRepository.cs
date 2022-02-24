using FelipeShopping.CarrinhoAPI.Config.ValueOjects;

namespace FelipeShopping.CarrinhoAPI.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoVO> FindCartByUserId(string usuarioId);
        Task<CarrinhoVO> SaveOrUpdateCart(CarrinhoVO carrinho);
        Task<bool> RemoveFromCart(long carrinhoDetailsId);
        Task<bool> ApplyCoupon(string usuarioId, string couponCode);
        Task<bool> RemoveCoupon(string usuarioId);
        Task<bool> ClearCart(string usuarioId);
    }
}
