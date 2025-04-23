using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace GAME4YOU.Services
{
    public class ProductService
    {
        private readonly Game4youDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public ProductService(Game4youDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
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

        public async Task AddProductAsync(Product product, IBrowserFile imageFile)
        {
            if (imageFile == null)
            {
                throw new ArgumentException("Zdjęcie produktu jest wymagane.");
            }

            var originalName = Path.GetFileNameWithoutExtension(imageFile.Name);
            var extension = Path.GetExtension(imageFile.Name);
            var uniqueSuffix = Guid.NewGuid().ToString().Substring(0, 8);
            var fileName = $"{originalName}_{uniqueSuffix}{extension}";

            var savePath = Path.Combine(_env.WebRootPath, "images", fileName);

            await using var stream = imageFile.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
            await using var fileStream = File.Create(savePath);
            await stream.CopyToAsync(fileStream);

            product.ImagePath = $"Images/{fileName}";
            product.CreatedAt = DateTime.UtcNow;
            product.IsActive = true;

            _dbContext.Products.Add(product);
            var result = await _dbContext.SaveChangesAsync();
        }
    }
}