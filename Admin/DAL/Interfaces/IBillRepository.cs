using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBillRepository
    {
        
        bool Create(BillModel bill);

        bool Update(BillModel bill);
        bool Delete(string id);
<<<<<<< HEAD
        List<BillModel> Search(int pageIndex, int pageSize, out long total, out int totalprice, string ten_khach, DateTime? fr_NgayTao,
=======
        List<BillModel> Search(int pageIndex, int pageSize, out long total, out int totalPrice, string ten_khach, DateTime? fr_NgayTao,
>>>>>>> afb0ee91e3675b6f09581069159743fbe366a495
           DateTime? to_NgayTao);
    }
}
