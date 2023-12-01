using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BillModel
    {
        public int BillId { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public List<DetailBillModel>? list_json_DetailBills { get; set; }

    }

    public class DetailBillModel
    {
        public int DetailBillID { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public string status { get; set; }
    }
}