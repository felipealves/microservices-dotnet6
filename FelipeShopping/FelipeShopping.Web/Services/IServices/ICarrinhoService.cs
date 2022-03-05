using FelipeShopping.Web.Models;

namespace FelipeShopping.Web.Services.IServices
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> FindCartByUserId(string token, string userId);
        Task<CarrinhoViewModel> AddItemToCart(string token, CarrinhoViewModel carrinho);
        Task<CarrinhoViewModel> UpdateCart(string token, CarrinhoViewModel carrinho);
        Task<bool> RemoveFromCart(string token, long id);
        Task<bool> ApplyCoupon(string token, CarrinhoViewModel carrinho, string cupom);
        Task<bool> RemoveCoupon(string token, string userId);
        Task<bool> ClearCart(string token, string userId);
        Task<CarrinhoViewModel> Checkout(string token, CarrinhoHeaderViewModel carrinhoHeader);
    }
}
