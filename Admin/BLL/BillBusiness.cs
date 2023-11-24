
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
        public BillBusiness(IBillRepository res)
        {
            _res = res;
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
        public List<BillModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao,
           DateTime? to_NgayTao)
        {

            return _res.Search(pageIndex, pageSize, out total, ten_khach, fr_NgayTao, to_NgayTao);

        }
    }
}