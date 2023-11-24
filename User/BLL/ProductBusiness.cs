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
        public ProductBusiness(IProductRepository res)
        {
            _res = res;
        }

        public List<ProductModel> GetNewProducts()
        {
            return _res.GetNewProducts();
        }


        public ProductModel GetById(string id)
        {
            return _res.GetById(id);
        }


        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);   
        }

    }
}
