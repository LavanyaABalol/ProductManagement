using ProductManagementModel;
using ProductManagementRepo;

namespace ProductManagementService
{
    public class ProductManagementService:IProductManagementService
    {
        private readonly IProductManagementRepo _productRepo;
        public ProductManagementService(IProductManagementRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Product AddProduct(Product receivedProduct)
        {
            try
            {
                if (receivedProduct != null)
                {
                    Product product = _productRepo.AddProduct(receivedProduct);
                    return product;
                }
                else
                {
                    throw new Exception("No product received to add");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        public bool DeleteProduct(int productId)
        {

            Product product = _productRepo.GetProductById(productId);
            if (product != null)
            {
                bool result = _productRepo.DeleteProduct(product);

                return result;

            }
            else return false;


        }

        public List<Product> GetAllproductService()
        {
            return _productRepo.GetAllproductService();
        }

        public Product GetProductById(int productId)
        {
            try
            {
               
                return _productRepo.GetProductById(productId);
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }


        }



        public Product UpdateProduct(Product receivedProduct)
        {
            try
            {
                if (receivedProduct != null)
                {
                    Product product = _productRepo.UpdateProduct(receivedProduct);
                    return product;
                }
                else
                {
                    throw new Exception("no product data to update");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}