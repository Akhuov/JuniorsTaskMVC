using WepAppJun.Application.DTOs;
using WepAppJun.Application.Interfaces.Products;
using WepAppJun.infrastructure.Models;
using WepAppJun.infrastructure.Repositories.Products.Interfaces;

namespace WepAppJun.Application.Services.Products
{
    public class ProductService : IProductService
    {

        private IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async ValueTask<bool> CreateProductAsync(ProductDto dto)
        {
            try
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                };
                var r = await _repository.CreateProductAsync(product);
                return r;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteProductAsync(Guid Id)
        {

            try
            {
                var res = await _repository.DeleteProductAsync(Id);
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var res = await _repository.GetAllProductsAsync();

                if (res != null)
                {
                    return res;
                }
                else
                {
                    throw new Exception("Product Not Found");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async ValueTask<Product> GetProductByIdAsync(Guid Id)
        {

            try
            {
                var res = await _repository.GetAllProductsAsync();
                if (res != null)
                {
                    var result = res.FirstOrDefault(x => x.Id == Id);
                    return result;

                }
                else
                {
                    throw new Exception("Products Not Found");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Product> UpdateProductAsync(Guid Id, ProductDto dto)
        {
            try
            {
                var product  = new Product()
                {
                    Id = Id,
                    Name = dto.Name,
                    Description = dto.Description,
                };
                var res = await _repository.UpdateProductAsync(product);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
