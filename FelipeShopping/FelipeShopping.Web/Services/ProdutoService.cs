using FelipeShopping.Web.Models;
using FelipeShopping.Web.Utils;
using FelipeShopping.Web.Services.IServices;
using System.Net.Http.Headers;

namespace FelipeShopping.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/produto";

        public ProdutoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutoModel>> FindAllProdutos(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProdutoModel>>();
        }

        public async Task<ProdutoModel> FindProdutoById(string token, long id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProdutoModel>();
        }

        public async Task<ProdutoModel> CreateProduto(string token, ProdutoModel model)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoModel>();
            else 
                throw new Exception("Ocorreu algo de errado ao criar um Produto!");
        }

        public async Task<ProdutoModel> UpdateProduto(string token, ProdutoModel model)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoModel>();
            else
                throw new Exception("Ocorreu algo de errado ao alterar um Produto!");
        }

        public async Task<bool> DeleteProdutoById(string token, long id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Ocorreu algo de errado ao deletar um Produto!");
        }
    }
}
