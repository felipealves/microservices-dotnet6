using FelipeShopping.Web.Models;
using FelipeShopping.Web.Services.IServices;
using FelipeShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FelipeShopping.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService ?? throw new ArgumentNullException(nameof(produtoService));
        }

        [Authorize]
        public async Task<IActionResult> ProdutoIndex()
        {
            var produtos = await _produtoService.FindAllProdutos("");
            return View(produtos);
        }

        [Authorize]
        public async Task<IActionResult> ProdutoCriar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProdutoCriar(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var retorno = await _produtoService.CreateProduto(token, model);
                if (retorno != null)
                    return RedirectToAction(nameof(ProdutoIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProdutoEditar(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _produtoService.FindProdutoById(token, id);
            if (model != null)
                return View(model);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProdutoEditar(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var retorno = await _produtoService.UpdateProduto(token, model);
                if (retorno != null)
                    return RedirectToAction(nameof(ProdutoIndex));
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProdutoDeletar(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _produtoService.FindProdutoById(token, id);
            if (model != null)
                return View(model);

            return NotFound();
        }

        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProdutoDeletar(ProdutoModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var retorno = await _produtoService.DeleteProdutoById(token, model.Id);
            if (retorno)
                return RedirectToAction(nameof(ProdutoIndex));

            return View(model);
        }
    }
}
