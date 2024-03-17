using Microsoft.EntityFrameworkCore;
using WepAppJun.infrastructure.AppDBContext;
using WepAppJun.infrastructure.Models;
using WepAppJun.infrastructure.Repositories.Products.Interfaces;

namespace WepAppJun.infrastructure.Repositories.Products.Services
{
    public class ProductRepository : IProductRepository
    {
        private TestDbContext _context;
        public ProductRepository(TestDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                var r = await _context.SaveChangesAsync();
                return true;
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
                var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
                if (res != null)
                {
                    _context.Products.Remove(res);
                    var r = await _context.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Product Not Found!");
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
                var res = await _context.Products.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                if (res != null)
                {
                    res.Description = product.Description;
                    res.Name = product.Name;

                    //res = product;
                    //_context.Products.Update(res); // If AsNoTracking() Used
                    var r = await _context.SaveChangesAsync();
                    return res;
                }

                else throw new Exception("Product Not Found!");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
