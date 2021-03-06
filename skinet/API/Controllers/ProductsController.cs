using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;

        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products= await _storeContext.Products.ToListAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }
    }
}