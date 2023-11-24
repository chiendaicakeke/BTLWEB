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
        public CustomerBusiness(ICustomerRepository res)
        {
            _res = res;
        }


        public CustomerModel GetById(string id)
        {
            return _res.GetById(id);
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

        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);
        }

    }
}
