using AutoMapper;
using FelipeShopping.ProdutoAPI.Data.ValueObjects;
using FelipeShopping.ProdutoAPI.Model;
using FelipeShopping.ProdutoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace FelipeShopping.ProdutoAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProdutoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoVO>> FindAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoVO>>(produtos);
        }

        public async Task<ProdutoVO> FindById(long id)
        {
            var produto = await _context.Produtos.Where(p=> p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<ProdutoVO> Create(ProdutoVO produtoVO)
        {
            var produto = _mapper.Map<Produto>(produtoVO);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<ProdutoVO> Update(ProdutoVO produtoVO)
        {
            var produto = _mapper.Map<Produto>(produtoVO);
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var produto = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (produto == null)
                    return false;


                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
