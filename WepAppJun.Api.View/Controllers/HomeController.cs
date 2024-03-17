using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WepAppJun.Api.View.Models;
using WepAppJun.Application.DTOs;
using WepAppJun.Application.Interfaces.Products;
using WepAppJun.infrastructure.Models;

namespace WepAppJun.Api.View.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async ValueTask<IActionResult> Index(string searchString)
        {
            var products = await _productService.GetAllProductsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return View(products);
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

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка удаления изделия: {ex.Message}");
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> UpdateProduct(Product product)
        {
            var res = _productService.UpdateProductAsync(product.Id,new ProductDto()
            {
                Name = product.Name,
                Description = product.Description,
            });
            return Ok(res);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateProduct(ProductDto product)
        {
            var res = _productService.CreateProductAsync(product);
            return Ok(res);
        }

    }
}
