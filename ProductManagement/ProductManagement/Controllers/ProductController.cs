using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductManagementModel;
using ProductManagementService;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagementService _productService;

        public ProductController(IProductManagementService productService)
        {
            _productService = productService;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Product> productList = _productService.GetAllproductService();
                if (productList != null)
                {
                    return Ok(productList);
                }
                else
                    return NotFound(productList);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Something went wrong while fetching All product list");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {

            try
            {
                Product product = _productService.GetProductById(productId);
                if (product != null)
                    return Ok(product);

                else
                    return NotFound("Product Not Found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Product access request failed");
            }

        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post(Product receivedProduct)
        {

            try
            {
                Product product = _productService.AddProduct(receivedProduct);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                    return BadRequest("Something went wrong");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }

        }

       
        [HttpPut("product")]
        public IActionResult Put(Product product)
        {
            try
            {
                Product p = _productService.GetProductById(product.ProductId);
                if (p != null)
                {
                    _productService.UpdateProduct(product);
                    return Ok(product);
                }
                else
                {
                    return NotFound("Product Not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Something went wrong while updating Product");

            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                Product product = _productService.GetProductById(productId);
                if (product != null)
                {
                    _productService.DeleteProduct(product.ProductId);
                    return Ok("Deleting Product was successful");
                }
                else
                {
                    return NotFound("Product Not Found to Delete");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
