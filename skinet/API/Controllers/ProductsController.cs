using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        [HttpGet]
        public string GetProducts(){
            return "This is list of product.";
        }

        [HttpGet("{id}")]        
        public string getProduct(int id){
            return "This is single product."+id;
        }
    }
}