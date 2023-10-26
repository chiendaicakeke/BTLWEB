using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BillModel
    {
        public int BillID { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserID { get; set; }
        public int Total { get; set; }
        public List<DetailBillModel>? list_json_DetailBill { get; set; }
    }
}