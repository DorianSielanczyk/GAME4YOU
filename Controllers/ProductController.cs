using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GAME4YOU.Controllers
{
    [Route("game4you")]
    public class ProductController : ControllerBase
    {
        private readonly Game4youDbContext _dbContext;

        public ProductController(Game4youDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }
    }
}
