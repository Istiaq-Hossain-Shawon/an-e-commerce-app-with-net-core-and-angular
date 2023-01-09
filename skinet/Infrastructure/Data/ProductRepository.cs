using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext= storeContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .ToListAsync();
        }
    }
}