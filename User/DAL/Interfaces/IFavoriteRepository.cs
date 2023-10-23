using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFavoriteRepository
    {
        List<FavoriteModel> GetAll();

        bool Create(FavoriteModel favorite);

        bool Update(FavoriteModel favorite);
        bool Delete(string id);
    }
}
