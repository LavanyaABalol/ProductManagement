using ProductManagementMVC.Models;

namespace ProductManagementMVC.Services
{
    public interface IProductServices
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
