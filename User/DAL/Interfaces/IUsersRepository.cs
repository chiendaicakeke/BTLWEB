using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsersRepository
    {
       List<UsersModel> GetAll();
       
       bool Create(UsersModel users);

       bool Update(UsersModel users);

       bool Delete(string id);
    }
}
