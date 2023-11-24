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
    public class ProductRepository : IProductRepository
    {
        private IDatabaseHelper _db;

        public ProductRepository(IDatabaseHelper db)
        {
            _db = db;
        }


        public ProductModel GetById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_by_id_Products",
                    "@ProductId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<ProductModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ProductModel product)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Products",
                "@ProductName", product.ProductName,
                "@Price", product.Price,
                "@Size", product.Size,
                "@Description", product.Description,
                "@Image", product.Image,
                "@ProductTypeId", product.ProductTypeId,
                "@CollectionId", product.CollectionId,
                "@ProducerId", product.ProducerId);
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

        public bool Update(ProductModel product)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_Products",
                "@ProductId", product.ProductId,
                "@ProductName", product.ProductName,
                "@Price", product.Price,
                "@Size", product.Size,
                "@Description", product.Description,
                "@Image", product.Image,
                "@ProductTypeId", product.ProductTypeId,
                "@CollectionId", product.CollectionId,
                "@ProducerId", product.ProducerId);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_Products",
                "@ProductId", id);
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

        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_kiem_Products",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ProductName", name
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
