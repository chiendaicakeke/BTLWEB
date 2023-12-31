﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICollectionBusiness
    {

        CollectionModel GetById(string id);

        List<CollectionModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
