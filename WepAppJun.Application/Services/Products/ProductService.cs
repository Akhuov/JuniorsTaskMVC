using AutoMapper;
using WepAppJun.Application.Interfaces.Products;
using WepAppJun.infrastructure.DTOs;
using WepAppJun.infrastructure.Models;
using WepAppJun.infrastructure.Repositories.Products.Interfaces;

namespace WepAppJun.Application.Services.Products
{
    public class ProductService : IProductService
    {

        private IProductRepository _repository;
        private IMapper _mapper;
        public ProductService(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<bool> CreateProductAsync(ProductDto dto)
        {
            try
            {

                var product = new Product();

                product = _mapper.Map<Product>(dto);

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

        public async ValueTask<List<ProductDto>> GetAllProductsAsync()
        {
            try
            {
                var res = await _repository.GetAllProductsAsync();

                var result = new List<ProductDto>();

                foreach (var item in res)
                {
                    result.Add(_mapper.Map<ProductDto>(item));
                }

                if (res != null)
                {
                    return result;
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


        public async ValueTask<ProductDto> GetProductByIdAsync(Guid Id)
        {
            try
            {
                var res = await _repository.GetAllProductsAsync();
                var product = res.FirstOrDefault(x => x.Id == Id);
                if (res != null)
                {
                    ProductDto result = _mapper.Map<ProductDto>(product);
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

        public async ValueTask<ProductDto> UpdateProductAsync(ProductDto dto)
        {

            try
            {
                var product = _mapper.Map<Product>(dto);
                var res = await _repository.UpdateProductAsync(product);
                return dto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  List<ProductDto> SearchProductByNameAsync(string searchString, List<ProductDto> products)
        {
            try
            {
                return products.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
