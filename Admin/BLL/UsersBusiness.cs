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

       
        public List<UserModel> GetAll()
        {
            return _res.GetAll();
        }

        public UserModel GetById(string id)
        {
            return _res.GetById(id);
        }

        public UserModel Login(string username, string password)
        {
            var user = _res.Login(username, password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }

        public bool Create(UserModel users)
        {
            return _res.Create(users);
        }
        
        public bool Update(UserModel users)
        {
            return _res.Update(users);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
