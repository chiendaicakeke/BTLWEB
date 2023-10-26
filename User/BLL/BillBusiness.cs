
using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class BillBusiness : IBillBusiness
    {
        private IBillRepository _res;
        private string secret;
        public BillBusiness(IBillRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        

        public bool Create(BillModel bill)
        {
            return _res.Create(bill);
        }

        public bool Update(BillModel bill)
        {
            return _res.Update(bill);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
