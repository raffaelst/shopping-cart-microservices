using Catalogs.Domain.Entities;
using Catalogs.Infra.Data.Context;
using Catalogs.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetPaged(int pageSize, int page)
        {
            IEnumerable<Product> products = await _context.Products.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return products;
        }
    }
}
