using DAL.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL
{
    public class MixerBusiness : IMixerBusiness
    {
        private IMixerRepository _res;
        private string secret;
        public MixerBusiness(IMixerRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }


        public List<MixerModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(MixerModel mixer)
        {
            return _res.Create(mixer);
        }

        public bool Update(MixerModel mixer)
        {
            return _res.Update(mixer);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

    }
}
