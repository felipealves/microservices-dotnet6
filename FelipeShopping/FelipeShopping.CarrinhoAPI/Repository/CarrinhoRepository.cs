using AutoMapper;
using FelipeShopping.CarrinhoAPI.Config.ValueOjects;
using FelipeShopping.CarrinhoAPI.Model;
using FelipeShopping.CarrinhoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace FelipeShopping.CarrinhoAPI.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CarrinhoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarrinhoVO> SaveOrUpdateCart(CarrinhoVO carrinhoVO)
        {
            var carrinho = _mapper.Map<Carrinho>(carrinhoVO);

            var carrinhoDetailFirst = carrinho.CarrinhoDetails.FirstOrDefault();

            if (carrinhoDetailFirst == null)
                return null;

            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == carrinhoDetailFirst.ProdutoId);

            //Valida se produto existe
            if (produto == null)
            {
                _context.Produtos.Add(carrinhoDetailFirst.Produto);
                await _context.SaveChangesAsync();
            }

            var carrinhoHeader = await _context.CarrinhoHeaders.AsNoTracking().FirstOrDefaultAsync(c => c.UsuarioId == carrinho.CarrinhoHeader.UsuarioId);

            //Valida se o Header existe
            if (carrinhoHeader == null)
            {
                _context.CarrinhoHeaders.Add(carrinho.CarrinhoHeader);
                await _context.SaveChangesAsync();

                carrinhoDetailFirst.CarrinhoHeaderId = carrinho.CarrinhoHeader.Id;
                carrinhoDetailFirst.Produto = null;

                _context.CarrinhoDetails.Add(carrinhoDetailFirst);
                await _context.SaveChangesAsync();
            }
            else
            {
                var carrinhoDetail = await _context.CarrinhoDetails.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == carrinhoDetailFirst.ProdutoId && p.CarrinhoHeaderId == carrinhoHeader.Id);

                //Valida se existe o Detail
                if (carrinhoDetail == null)
                {
                    carrinhoDetailFirst.CarrinhoHeaderId = carrinhoHeader.Id;
                    carrinhoDetailFirst.Produto = null;

                    _context.CarrinhoDetails.Add(carrinhoDetailFirst);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    carrinhoDetailFirst.Produto = null;
                    carrinhoDetailFirst.Contador += carrinhoDetail.Contador;
                    carrinhoDetailFirst.Id = carrinhoDetail.Id;
                    carrinhoDetailFirst.CarrinhoHeaderId = carrinhoDetail.CarrinhoHeaderId;

                    _context.CarrinhoDetails.Update(carrinhoDetailFirst);
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CarrinhoVO>(carrinho);
        }
        public async Task<CarrinhoVO> FindCartByUserId(string usuarioId)
        {
            var carrinho = new Carrinho
            {
                CarrinhoHeader = await _context.CarrinhoHeaders.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId)
            };

            carrinho.CarrinhoDetails = _context.CarrinhoDetails.Where(c => c.CarrinhoHeaderId == carrinho.CarrinhoHeader.Id).Include(c => c.Produto);

            return _mapper.Map<CarrinhoVO>(carrinho);
        }

        public async Task<bool> RemoveFromCart(long carrinhoDetailsId)
        {
            try
            {
                var carrinhoDetail = await _context.CarrinhoDetails.FirstOrDefaultAsync(c => c.Id == carrinhoDetailsId);

                int total = _context.CarrinhoDetails.Where(c => c.CarrinhoHeaderId == carrinhoDetail.CarrinhoHeaderId).Count();

                _context.CarrinhoDetails.Remove(carrinhoDetail);

                if (total == 1)
                {
                    var carrinhoHeaderARemover = await _context.CarrinhoHeaders.FirstOrDefaultAsync(c => c.Id == carrinhoDetail.CarrinhoHeaderId);

                    _context.CarrinhoHeaders.Remove(carrinhoHeaderARemover);
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ClearCart(string usuarioId)
        {
            var carrinhoHeader = await _context.CarrinhoHeaders.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

            if (carrinhoHeader != null)
            {
                var carrinhoDetailsARemover = _context.CarrinhoDetails.Where(c => c.CarrinhoHeaderId == carrinhoHeader.Id);

                _context.CarrinhoDetails.RemoveRange(carrinhoDetailsARemover);

                _context.CarrinhoHeaders.Remove(carrinhoHeader);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> ApplyCoupon(string usuarioId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string usuarioId)
        {
            throw new NotImplementedException();
        }

    }
}
