using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DetailBillModel
    {
        public int DetailBillID { get; set; }
        public int BillID { get; set; }
        public DateTime CreateAt { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public string Total { get; set; }
    }
}
