using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillRepository : IBillRepository
    {
        private IDatabaseHelper _db;

        public BillRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public bool Create(BillModel bill)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Bills",
                "@TotalPrice", bill.TotalPrice,
                "@Status", bill.Status,
                "@CustomerId", bill.CustomerId,
                "@list_json_DetailBills", bill.list_json_DetailBills != null ? MessageConvert.SerializeObject(bill.list_json_DetailBills) : null);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public List<BillModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, 
            DateTime? to_NgayTao)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_kiem_Bills",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khach", ten_khach,
                    "@fr_NgayTao", fr_NgayTao,
                    "@to_NgayTao", to_NgayTao
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<BillModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
