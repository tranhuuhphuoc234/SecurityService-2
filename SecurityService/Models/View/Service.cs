﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityService.Models.View
{
    public class Service
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public bool status { get; set; }

        public string description { get; set; }

        public string image { get; set; }
    }
}
