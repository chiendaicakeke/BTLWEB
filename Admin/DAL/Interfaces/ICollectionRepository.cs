using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICollectionRepository
    {
        CollectionModel GetById(string id);

        bool Create(CollectionModel colection);

        bool Update(CollectionModel colection);
        bool Delete(string id);
        List<CollectionModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
