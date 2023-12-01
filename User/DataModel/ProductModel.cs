using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ProductTypeId { get; set; }
        public int CollectionId { get; set; }
        public int ProducerId { get; set; }
        public string ImageAfter { get; set; }
    }

    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }
}
