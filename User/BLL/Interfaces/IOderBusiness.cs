﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOderBusiness
    {

        List<OderModel> GetAll();

        bool Create(OderModel oder);

        bool Update(OderModel oder);

        bool Delete(string id);
    }
}
