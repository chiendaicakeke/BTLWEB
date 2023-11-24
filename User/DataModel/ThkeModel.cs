using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ThkeModel
    {     
        public int CustomerName { get; set; }
        public string Adress { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
    }
}
