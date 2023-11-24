using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerBusiness
    {

        CustomerModel GetById(string id);
        bool Create(CustomerModel customer);
        bool Update(CustomerModel customer);
        bool Delete(string id);
        List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
