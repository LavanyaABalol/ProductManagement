using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }

        public Boolean IsActive { get; set; }



        public string productServiceizesAvailable { get; set; }

        [NotMapped]
        public string PlaceOfOriginName { get; set; }
        public int PlaceOfOriginId { get; set; } //Foreign Key
    }
}