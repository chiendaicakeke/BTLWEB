using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IColectionRepository
    {
        List<ColectionModel> GetAll();

        bool Create(ColectionModel colection);

        bool Update(ColectionModel colection);
        bool Delete(string id);
    }
}
