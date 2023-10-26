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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_bill_create",
                "@CreateTime", bill.CreateTime,
                "@UserID", bill.UserID,
                "@Total", bill.Total,
                "@list_json_DetailBill", bill.list_json_DetailBill != null ? MessageConvert.SerializeObject(bill.list_json_DetailBill) : null);

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

        public bool Update(BillModel bill)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Bill_update",
                "@BillID", bill.BillID,
                "@CreateTime", bill.CreateTime,
                "@UserID", bill.UserID,
                "@Total", bill.Total,
                "@list_json_DetailBill", bill.list_json_DetailBill != null ? MessageConvert.SerializeObject(bill.list_json_DetailBill) : null);
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Bill_delete",
                "@BillID", id);
                ;
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


    }
}
