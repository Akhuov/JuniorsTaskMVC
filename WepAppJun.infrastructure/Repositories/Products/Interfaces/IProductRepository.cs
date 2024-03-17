using WepAppJun.infrastructure.Models;

namespace WepAppJun.infrastructure.Repositories.Products.Interfaces
{
    public interface IProductRepository
    {
        public ValueTask<bool> CreateProductAsync(Product product);
        public ValueTask<bool> DeleteProductAsync(Guid Id);
        public ValueTask<List<Product>> GetAllProductsAsync();
        public ValueTask<Product> UpdateProductAsync(Product product);

    }
}
