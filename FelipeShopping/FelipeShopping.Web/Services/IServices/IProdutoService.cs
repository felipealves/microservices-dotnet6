using FelipeShopping.Web.Models;

namespace FelipeShopping.Web.Services.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> FindAllProdutos(string token);
        Task<ProdutoViewModel> FindProdutoById(string token, long id);
        Task<ProdutoViewModel> CreateProduto(string token, ProdutoViewModel model);
        Task<ProdutoViewModel> UpdateProduto(string token, ProdutoViewModel model);
        Task<bool> DeleteProdutoById(string token, long id);
    }
}
