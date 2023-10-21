using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _res;
        private string secret;
        public CustomerBusiness(ICustomerRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        public List<CustomerModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(CustomerModel customer)
        {
            return _res.Create(customer);
        }

        public bool Update(CustomerModel customer)
        {
            return _res.Update(customer);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
