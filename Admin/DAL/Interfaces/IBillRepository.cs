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
        List<BillModel> Search(int pageIndex, int pageSize, out long total, out int totalPrice, string ten_khach, DateTime? fr_NgayTao,
           DateTime? to_NgayTao);
    }
}
