using WepAppJun.infrastructure.DTOs;
using WepAppJun.infrastructure.Models;

namespace WepAppJun.Application.Interfaces.Products
{
    public interface IProductService
    {
        public ValueTask<bool> CreateProductAsync(ProductDto dto);
        public ValueTask<ProductDto> UpdateProductAsync(ProductDto dto);
        public ValueTask<bool> DeleteProductAsync(Guid Id);
        public ValueTask<List<ProductDto>> GetAllProductsAsync();
        public ValueTask<ProductDto> GetProductByIdAsync(Guid Id);
        public List<ProductDto> SearchProductByNameAsync(string searchString, List<ProductDto> products);

    }
}
