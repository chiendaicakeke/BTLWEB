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
    public class CollectionRepository : ICollectionRepository
    {
        private IDatabaseHelper _db;

        public CollectionRepository(IDatabaseHelper db)
        {
            _db = db;
        }


  
        public CollectionModel GetById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_by_id_Collections",
                    "@CollectionId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<CollectionModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Create(CollectionModel colection)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Collections",
                "@CollectionName", colection.CollectionName,
                "@Description", colection.Description,
                "@Image", colection.Image);
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

        public bool Update(CollectionModel colection)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_Collections",
                "@CollectionID", colection.CollectionId,
                "@CollectionName", colection.CollectionName,
                "@Description", colection.Description,
                "@Image", colection.Image);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_Collections",
                "@CollectionId", id);
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

        public List<CollectionModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_kiem_Collections",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@CollectionName", name
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CollectionModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
