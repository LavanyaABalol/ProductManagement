using ProductManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementRepo
{
    public interface IProductManagementRepo
    {
        public Product AddProduct(Product receivedProduct);
        public Product UpdateProduct(Product receivedProduct);
        public bool DeleteProduct(Product receivedProduct);
      
        public Product GetProductById(int productId);

        public List<Product> GetAllproductService();
    }
}
