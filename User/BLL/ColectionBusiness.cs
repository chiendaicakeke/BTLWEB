using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class ColectionBusiness : IColectionBusiness
    {
        private IColectionRepository _res;
        private string secret;
        public ColectionBusiness(IColectionRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        public List<ColectionModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(ColectionModel colection)
        {
            return _res.Create(colection);
        }

        public bool Update(ColectionModel colection)
        {
            return _res.Update(colection);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
