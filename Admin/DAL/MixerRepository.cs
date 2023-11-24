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
    public class MixerRepository : IMixerRepository
    {
        private IDatabaseHelper _db;

        public MixerRepository(IDatabaseHelper db)
        {
            _db = db;
        }


        public List<MixerModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_hien_thi_Mixer");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<MixerModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Create(MixerModel mixer)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Mixer",
                "@MixerName", mixer.MixerName,
                "@Description", mixer.Description,
                "@ProductID", mixer.ProductID);
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

        public bool Update(MixerModel mixer)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_Mixer",
                "@MixerID", mixer.MixerID,
                "@MixerName", mixer.MixerName,
                "@Description", mixer.Description,
                "@ProductID", mixer.ProductID);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_Mixer",
                "@MixerID", id);
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
