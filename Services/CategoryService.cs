using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.EntityFrameworkCore;

namespace GAME4YOU.Services
{
    public class CategoryService
    {
        private readonly Game4youDbContext _dbContext;

        public CategoryService(Game4youDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
