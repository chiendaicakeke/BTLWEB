using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class CollectionBusiness : ICollectionBusiness
    {
        private ICollectionRepository _res;
        public CollectionBusiness(ICollectionRepository res)
        {
            _res = res;
        }


      

        public CollectionModel GetById(string id)
        {
            return _res.GetById(id);
        }

        public List<CollectionModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            return _res.Search(pageIndex, pageSize, out total, name);   
        }

    }
}
