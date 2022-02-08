using FelipeShopping.Web.Models;

namespace FelipeShopping.Web.Services.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> FindAllProdutos(string token);
        Task<ProdutoModel> FindProdutoById(string token, long id);
        Task<ProdutoModel> CreateProduto(string token, ProdutoModel model);
        Task<ProdutoModel> UpdateProduto(string token, ProdutoModel model);
        Task<bool> DeleteProdutoById(string token, long id);
    }
}
