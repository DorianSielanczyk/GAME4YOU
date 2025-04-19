using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.EntityFrameworkCore;

namespace GAME4YOU.Services
{
    public class ProductService
    {
        private readonly Game4youDbContext _dbContext;

        public ProductService(Game4youDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.Where(p => p.IsActive)
                                            .Include(p => p.Category)
                                            .Include(p => p.User)
                                            .ToListAsync();
        }
        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.Include(p => p.Category)
                                            .Where(p => p.CategoryId == categoryId)
                                            .Include(p => p.User)
                                            .ToListAsync();
        }
    }
}