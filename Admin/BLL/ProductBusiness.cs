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


        public ProductModel GetById(string id)
        {
            return _res.GetById(id);
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
        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);   
        }

    }
}
