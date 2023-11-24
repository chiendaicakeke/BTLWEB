using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductBusiness
    {

        ProductModel GetById(string id);

        bool Create(ProductModel product);

        bool Update(ProductModel product);
        bool Delete(string id);

        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
