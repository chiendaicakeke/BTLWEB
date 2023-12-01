using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CollectionModel
    {
        public int CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageAfter { get; set; }
    }
}