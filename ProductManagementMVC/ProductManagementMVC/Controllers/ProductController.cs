using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductManagementMVC.Models;
using ProductManagementMVC.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementMVC.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productS;

        public ProductController(IProductServices productS)
        {
            _productS = productS;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Product> productList=_productS.getAllProducts();
                if (productList != null)
                {
                    return Ok(productList);
                }
                else
                    return NotFound(productList);
            }
           
           catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Something went wrong while fetching All product list");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{productId}")]
        public IActionResult Get(string productId)
        {

            try
            {
                Product product = _productS.getProductById(productId);
                if (product != null)
                    return Ok(product);

                else
                    return NotFound("Product Not Found");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Product access request failed");
            }
        
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post(Product p)
        {

            try
            {
                Product product = _productS.addProduct(p);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                    return BadRequest("Something went wrong");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{productId}")]
        public IActionResult Delete(string productId)
        {
            try
            {
                bool result=_productS.deleteProduct(productId);
                if(result)
                {
                    return Ok("Deleting Product was successful");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
