using WepAppJun.Application.DTOs;
using WepAppJun.infrastructure.Models;

namespace WepAppJun.Application.Interfaces.Products
{
    public interface IProductService
    {
        public ValueTask<bool> CreateProductAsync(ProductDto dto);
        public ValueTask<Product> UpdateProductAsync(Guid Id, ProductDto dto);
        public ValueTask<bool> DeleteProductAsync(Guid Id);
        public ValueTask<List<Product>> GetAllProductsAsync();
        public ValueTask<Product> GetProductByIdAsync(Guid Id);
    }
}
