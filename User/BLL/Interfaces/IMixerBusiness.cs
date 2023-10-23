using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMixerBusiness
    {

        List<MixerModel> GetAll();

        bool Create(MixerModel mixer);

        bool Update(MixerModel mixer);

        bool Delete(string id);
    }
}
