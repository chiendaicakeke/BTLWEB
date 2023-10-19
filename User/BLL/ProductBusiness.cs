using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _res;
        private string secret;
        public ProductBusiness(IProductRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        public List<ProductModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(ProductModel product)
        {
            return _res.Create(product);
        }

        public bool Update(ProductModel product)
        {
            return _res.Update(product);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
