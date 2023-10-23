
using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class FavoriteBusiness : IFavoriteBusiness
    {
        private IFavoriteRepository _res;
        private string secret;
        public FavoriteBusiness(IFavoriteRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        public List<FavoriteModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(FavoriteModel favorite)
        {
            return _res.Create(favorite);
        }

        public bool Update(FavoriteModel favorite)
        {
            return _res.Update(favorite);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
