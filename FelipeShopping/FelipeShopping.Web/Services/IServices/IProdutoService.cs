using FelipeShopping.Web.Models;

namespace FelipeShopping.Web.Services.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> FindAllProdutos();
        Task<ProdutoModel> FindProdutoById(long id);
        Task<ProdutoModel> CreateProduto(ProdutoModel model);
        Task<ProdutoModel> UpdateProduto(ProdutoModel model);
        Task<bool> DeleteProdutoById(long id);
    }
}
