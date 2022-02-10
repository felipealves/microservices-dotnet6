using FelipeShopping.ProdutoAPI.Data.ValueObjects;
using FelipeShopping.ProdutoAPI.Repository;
using FelipeShopping.ProdutoAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FelipeShopping.ProdutoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController (IProdutoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> FindAll()
        {
            var produto = await _repository.FindAll();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> FindById(long id)
        {
            var produto = await _repository.FindById(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProdutoVO>> Create([FromBody] ProdutoVO produtoVO)
        {
            if (produtoVO == null)
                return BadRequest();

            var produto = await _repository.Create(produtoVO);
            return Ok(produto);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProdutoVO>> Update([FromBody] ProdutoVO produtoVO)
        {
            if (produtoVO == null)
                return BadRequest();

            var produto = await _repository.Update(produtoVO);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProdutoVO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
