using FelipeShopping.ProdutoAPI.Data.ValueObjects;

namespace FelipeShopping.ProdutoAPI.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoVO>> FindAll();
        Task<ProdutoVO> FindById(long id);
        Task<ProdutoVO> Create(ProdutoVO produtoVO);
        Task<ProdutoVO> Update(ProdutoVO produtoVO);
        Task<bool> Delete(long id);
    }
}
