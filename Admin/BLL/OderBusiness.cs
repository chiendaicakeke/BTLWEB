

using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class OderBusiness : IOderBusiness
    {
        private IOderRepository _res;
        public OderBusiness(IOderRepository res)
        {
            _res = res;
        }


        public List<OderModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(OderModel oder)
        {
            return _res.Create(oder);
        }

        public bool Update(OderModel   oder )
        {
            return _res.Update(oder);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
