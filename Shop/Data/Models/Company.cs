﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Company
    {
        public int id { set; get; }

        public string nameCompany { set; get; }

        public IEnumerable<Car> allCars { get; set; }
    }
}
