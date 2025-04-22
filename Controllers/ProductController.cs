using GAME4YOU.Data;
using GAME4YOU.Entities;
using GAME4YOU.Models;
using GAME4YOU.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GAME4YOU.Controllers
{
    [Route("game4you/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
    }
}
