using Microsoft.AspNetCore.Mvc;
using WepAppJun.Application.DTOs;
using WepAppJun.Application.Interfaces.Products;

namespace WepAppJun.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductsAsync()
        {
            var res = await _productService.GetAllProductsAsync();
            return Ok(res);
        }


        [HttpPost]
        public async ValueTask<IActionResult> CreateProductAsync(ProductDto dto)
        {
            var res = await _productService.CreateProductAsync(dto);
            return Ok(res);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProductByIdAsync(Guid Id)
        {
            var res = await _productService.DeleteProductAsync(Id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateProductByIdAsync(Guid Id, ProductDto dto)
        {
            var res = _productService.UpdateProductAsync(Id, dto);
            return Ok(res);
        }
    }
}
