using ProductManagementMVC.Models;

namespace ProductManagementMVC.Repos
{
    public class ProductClientRepo:IProductClientRepo
    {
        private readonly EFDBcontext _dbcontext;
        public ProductClientRepo(EFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Product addProduct(Product product)
        {

            try
            {
                _dbcontext.products.Add(product);
                _dbcontext.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
         }

        public bool deleteProduct(string productId)
        {
            try
            {
                Product p = (Product)_dbcontext.products.Where(x => x.ProductId == productId);

                if (p != null)
                {
                    _dbcontext.products.Remove(p);
                    return true;
                }

                else return false;

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Product> getAllProducts()
        {
            try
            {
                List<Product> listProduct=_dbcontext.products.ToList();
                return listProduct;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public Product getProductById(string productId)
        {

            try
            {
                Product product = _dbcontext.products.FirstOrDefault(x => x.ProductId == productId);

                return product;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }


        }

        public Product getProductByName(string productName)
        {
            try
            {
                Product product = _dbcontext.products.FirstOrDefault(x => x.ProductName == productName);

                return product;

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
          
        }

        public Product updateProduct(Product p)
        {
            try
            {
                Product product = _dbcontext.products.FirstOrDefault(x => x.ProductId == p.ProductId);

                if (product != null)
                {
                    product.ProductId = p.ProductId;
                    product.ProductName = p.ProductName;
                    product.ProductPrice = p.ProductPrice;
                    product.ProductDescription = p.ProductDescription;
                    product.Availibility = p.Availibility;
                    product.Instock = p.Instock;

                    _dbcontext.SaveChanges();
                    return product;
                }
                else throw new Exception("Product no Found");

               

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
          

           // throw new NotImplementedException();
        }
    }
}
