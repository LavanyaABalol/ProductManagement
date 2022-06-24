using ProductManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService
{
    public interface IProductManagementService
    {
        public Product AddProduct(Product receivedProduct);
        public Product UpdateProduct(Product receivedProduct);
        public bool DeleteProduct(int productId);
       
        public Product GetProductById(int productId);

       
        public List<Product> GetAllproductService();
    }
}
