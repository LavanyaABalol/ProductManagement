namespace ProductManagementMVC.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }

        public Boolean Instock { get; set; }

        public string  Availibility { get; set; }
    }
}
