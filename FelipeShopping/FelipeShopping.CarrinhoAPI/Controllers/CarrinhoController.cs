using FelipeShopping.CarrinhoAPI.Config.ValueOjects;
using FelipeShopping.CarrinhoAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FelipeShopping.CarrinhoAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoRepository _repository;

        public CarrinhoController(ICarrinhoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("buscar-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoVO>> FindById(string usuarioId)
        {
            var carrinho = await _repository.FindCartByUserId(usuarioId);
            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        [HttpPost("adicionar-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoVO>> AddCart(CarrinhoVO carrinhoVo)
        {
            var carrinho = await _repository.SaveOrUpdateCart(carrinhoVo);
            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        [HttpPut("atualizar-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoVO>> UpdateCart(CarrinhoVO carrinhoVo)
        {
            var carrinho = await _repository.SaveOrUpdateCart(carrinhoVo);
            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        [HttpDelete("remover-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}