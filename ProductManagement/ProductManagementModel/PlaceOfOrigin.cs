using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementModel
{
    public class PlaceOfOrigin
    {
        [Key]
        public int PlaceOfOriginId { get; set; }

        public string PlaceOfOriginName { get; set; }
    }
}
