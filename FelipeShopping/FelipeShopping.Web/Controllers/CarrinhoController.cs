using FelipeShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FelipeShopping.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(IProdutoService produtoService, ICarrinhoService carrinhoService)
        {
            _produtoService = produtoService;
            _carrinhoService = carrinhoService;
        }

        [Authorize]
        public async Task<IActionResult> CarrinhoIndex()
        {
            return View(await BuscarCarrinhoPorUsuario());
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var usuarioId = User?.Claims?.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _carrinhoService.RemoveFromCart(token, id);

            if (response)
                return RedirectToAction(nameof(CarrinhoIndex));

            return View();
        }

        private async Task<Models.CarrinhoViewModel> BuscarCarrinhoPorUsuario()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var usuarioId = User?.Claims?.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _carrinhoService.FindCartByUserId(token, usuarioId);

            if (response?.CarrinhoHeader != null)
            {
                foreach (var details in response.CarrinhoDetails)
                {
                    response.CarrinhoHeader.ValorCompra = details.Produto.Valor * details.Contador;
                }
            }

            return response;
        }
    }
}
