using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDatabaseHelper _db;

        public CustomerRepository(IDatabaseHelper db)
        {
            _db = db;
        }



        public CustomerModel GetById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_by_id_Customers ",
                    "@CustomerId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<CustomerModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(CustomerModel customer)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Customers",
                "@CustomerName", customer.CustomerName,
                "@Email", customer.Email,
                "@Phone", customer.Phone,
                "@Address", customer.Address,
                "@UserId", customer.UserId);

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

        public bool Update(CustomerModel customer)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_Customers",
                "@CustomerID", customer.CustomerId,
                "@CustomerName", customer.CustomerName,
                "@Email", customer.Email,
                "@Phone", customer.Phone,
                "@Address", customer.Address,
                "@UserId", customer.UserId);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_Customers",
                "@CustomerId", id);
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

        public List<CustomerModel> Search( int pageIndex, int pageSize,  out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_kiem_Customers",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", name
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CustomerModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
