﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBillRepository
    {
        
        bool Create(BillModel bill);

     
        List<BillModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao,
           DateTime? to_NgayTao);
    }
}
