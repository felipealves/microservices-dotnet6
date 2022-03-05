using FelipeShopping.Web.Models;
using FelipeShopping.Web.Services.IServices;
using FelipeShopping.Web.Utils;
using System.Net.Http.Headers;

namespace FelipeShopping.Web.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/carrinho";

        public CarrinhoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CarrinhoViewModel> FindCartByUserId(string token, string userId)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/buscar-carrinho/{userId}");
            return await response.ReadContentAs<CarrinhoViewModel>();
        }

        public async Task<CarrinhoViewModel> AddItemToCart(string token, CarrinhoViewModel model)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/adicionar-carrinho", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CarrinhoViewModel>();
            else
                throw new Exception("Ocorreu algo de errado ao adicionar o item no Carrinho!");
        }

        public async Task<CarrinhoViewModel> UpdateCart(string token, CarrinhoViewModel model)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/atualizar-carrinho", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CarrinhoViewModel>();
            else
                throw new Exception("Ocorreu algo de errado ao atualizar o item no Carrinho!");
        }

        public async Task<bool> RemoveFromCart(string token, long id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remover-carrinho/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Ocorreu algo de errado ao excluir o item do Carrinho!");
        }

        public async Task<bool> ApplyCoupon(string token, CarrinhoViewModel carrinho, string cupom)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string token, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string token, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoViewModel> Checkout(string token, CarrinhoHeaderViewModel carrinhoHeader)
        {
            throw new NotImplementedException();
        }
    }
}
