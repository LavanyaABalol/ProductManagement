using ProductManagementMVC.Models;
using ProductManagementMVC.Repos;

namespace ProductManagementMVC.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductClientRepo _productR;
        public ProductServices(IProductClientRepo productR)
        {
            _productR = productR;
        }
        public Product addProduct(Product p)
        {
            try
            {
                if(p!=null)
                {
                    Product product = _productR.addProduct(p);
                    return product;
                }
                else
                {
                    throw new Exception("No product received to add");
                }
             

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
           
               
        }

        public bool deleteProduct(string productId)
        {

            return _productR.deleteProduct(productId);
          
        }

        public List<Product> getAllProducts()
        {
            return _productR.getAllProducts();
        }

        public Product getProductById(string productId)
        {
            try
            {
                if (productId != null)
                    return _productR.getProductById(productId);
                else
                    throw new Exception("No ProductId received for Search");

            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return null;

            }
          

        }

        public Product getProductByName(string productName)
        {
            try
            {
                if (productName != null)
                    return _productR.getProductByName(productName);
                else
                    throw new Exception("No product name received for Search");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }

        public Product updateProduct(Product p)
        {
            try
            {
                if(p!=null)
                {
                    Product product = _productR.updateProduct(p);
                    return product;
                }
                else
                {
                    throw new Exception("no product data to update");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
