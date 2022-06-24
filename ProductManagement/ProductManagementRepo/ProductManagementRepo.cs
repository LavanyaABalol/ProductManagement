using ProductManagementDBContext;
using ProductManagementModel;

namespace ProductManagementRepo
{
    public class ProductManagementRepo:IProductManagementRepo
    {

        private readonly EFDBcontext _dbcontext;
        public ProductManagementRepo(EFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Product AddProduct(Product product)
        {

            try
            {
                ProductManagementModel.PlaceOfOrigin placeOfOrigin = _dbcontext.place_of_origin.FirstOrDefault(x => x.PlaceOfOriginId == product.PlaceOfOriginId);
                if (placeOfOrigin != null)
                {
                    _dbcontext.productService.Add(product);
                    _dbcontext.SaveChanges();
                    return product;
                }

                else
                {
                    throw new Exception("Place of Origin Not properly mentioned");
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteProduct(Product productRepoeceived)
        {
            try
            {
                //ProductManagementModel.Product p = (ProductManagementModel.Product)_dbcontext.productService.Where(x => x.ProductId == productRepoeceived.ProductId);

                _dbcontext.productService.Remove(productRepoeceived);
                _dbcontext.SaveChanges();
                return true;




            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Product> GetAllproductService()
        {

            try
            {
                List<Product> productlist = new List<Product>();
                var listproduct =
                     (from prod in _dbcontext.productService
                      join placeoforigin_var in _dbcontext.place_of_origin
                      on prod.PlaceOfOriginId equals placeoforigin_var.PlaceOfOriginId
                      select new
                      {
                          ProductId = prod.ProductId,
                          ProductName = prod.ProductName,
                          ProductDescription = prod.ProductDescription,
                          ProductPrice = prod.ProductPrice,
                          IsActive = prod.IsActive,
                          PlaceOfOriginId = prod.PlaceOfOriginId,
                          PlaceOfOriginName = placeoforigin_var.PlaceOfOriginName,
                          productServiceizesAvailable = prod.productServiceizesAvailable
                      });
              
                foreach (var list in listproduct)
                {
                    Product getproduct = new Product();
                    getproduct.ProductId = list.ProductId;
                    getproduct.ProductName = list.ProductName;
                    getproduct.ProductPrice = list.ProductPrice;
                    getproduct.ProductDescription = list.ProductDescription;
                    getproduct.IsActive = list.IsActive;
                    getproduct.productServiceizesAvailable = list.productServiceizesAvailable;
                    getproduct.PlaceOfOriginId = list.PlaceOfOriginId;
                    getproduct.PlaceOfOriginName = list.PlaceOfOriginName;
                    productlist.Add(getproduct);
                  

                }
               
                return productlist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public Product GetProductById(int receivedProductId)
        {

            try
            {
                ProductManagementModel.Product product = _dbcontext.productService.FirstOrDefault(x => x.ProductId == receivedProductId);

                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }


        }

       
        public Product UpdateProduct(Product receivedProduct)
        {
            try
            {
                Product product = _dbcontext.productService.FirstOrDefault(x => x.ProductId == receivedProduct.ProductId);

                if (product != null)
                {
                    product.ProductId = receivedProduct.ProductId;
                    product.ProductName = receivedProduct.ProductName;
                    product.ProductPrice = receivedProduct.ProductPrice;
                    product.ProductDescription = receivedProduct.ProductDescription;
                    product.productServiceizesAvailable = receivedProduct.productServiceizesAvailable;
                    product.IsActive = receivedProduct.IsActive;
                    product.PlaceOfOriginId = receivedProduct.PlaceOfOriginId;

                    _dbcontext.SaveChanges();
                    return product;
                }
                else throw new Exception("product no found");



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }



            
        }
    }


}
