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
    public class UsersRepository : IUsersRepository
    {
        private IDatabaseHelper _db;

        public UsersRepository(IDatabaseHelper db)
        {
            _db = db;
        }

       
        public List<UserModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_hien_thi_Users");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserModel GetById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_theo_id_Users",
                    "@UserID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserModel Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_login", 
                    "@UserName",username,
                    "@Password", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Create(UserModel users)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_Users",
                "@UserName", users.UserName,
                "@Password", users.Password,
                "@Role", users.Role);
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

        public bool Update(UserModel users)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_Users",
                "@UserID", users.UserId,
                "@UserName", users.UserName,
                "@Password", users.Password,
                "@Role", users.Role);
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
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_Users",
                "@UserID", id);
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
