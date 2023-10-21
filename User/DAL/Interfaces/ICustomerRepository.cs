﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerModel> GetAll();

        bool Create(CustomerModel customer);

        bool Update(CustomerModel customer);
        bool Delete(string id);
    }
}
