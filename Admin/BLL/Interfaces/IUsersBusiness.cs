using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsersBusiness
    {

        List<UserModel> GetAll();

        UserModel GetById(string id);

        UserModel Login(string username, string password);

        bool Create(UserModel users);

        bool Update(UserModel users);

        bool Delete(string id);
    }
}
