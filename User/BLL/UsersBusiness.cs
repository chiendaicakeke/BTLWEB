using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class UsersBusiness : IUsersBusiness
    {
        private IUsersRepository _res;
        private string secret;
        public UsersBusiness(IUsersRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

       
        public List<UsersModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(UsersModel users)
        {
            return _res.Create(users);
        }

        public bool Update(UsersModel users)
        {
            return _res.Update(users);
        }
        public bool Delete(string users)
        {
            return _res.Delete(users);
        }
    }
}
