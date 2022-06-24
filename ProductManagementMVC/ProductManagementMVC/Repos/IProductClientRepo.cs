using ProductManagementMVC.Models;

namespace ProductManagementMVC.Repos
{
    public interface IProductClientRepo
    {
        public Product addProduct(Product p);
        public Product updateProduct(Product p);
        public bool deleteProduct(string productId);
      //  public Product viewProduct(string productId);
        public Product getProductById(string productId);
       
        public Product getProductByName(string productName);
        public List<Product> getAllProducts();   
    }
}
