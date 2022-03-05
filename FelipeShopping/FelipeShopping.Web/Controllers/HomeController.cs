using FelipeShopping.Web.Models;
using FelipeShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FelipeShopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoService _carrinhoService;

        public HomeController(ILogger<HomeController> logger, IProdutoService produtoService, ICarrinhoService carrinhoService)
        {
            _logger = logger;
            _produtoService = produtoService;
            _carrinhoService = carrinhoService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.FindAllProdutos("");
            return View(produtos);
        }

        [Authorize]
        public async Task<IActionResult> Detalhes(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var produto = await _produtoService.FindProdutoById(token, id);
            return View(produto);
        }

        [HttpPost]
        [ActionName("Detalhes")]
        [Authorize]
        public async Task<IActionResult> DetalhesPost(ProdutoViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            CarrinhoViewModel carrinho = new()
            {
                CarrinhoHeader = new CarrinhoHeaderViewModel
                {
                    UsuarioId = User?.Claims?.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CarrinhoDetailViewModel carrinhoDetail = new()
            {
                Contador = model.Count,
                ProdutoId = model.Id,
                Produto = await _produtoService.FindProdutoById(token, model.Id)
            };

            var carrinhoDetails = new List<CarrinhoDetailViewModel>
            { 
                carrinhoDetail
            };

            carrinho.CarrinhoDetails = carrinhoDetails;

            var response = await _carrinhoService.AddItemToCart(token, carrinho);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}