using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {

        List<ProductModel> GetNewProducts();
        ProductModel GetById(string id);

        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
