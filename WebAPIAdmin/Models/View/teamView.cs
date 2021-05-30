using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class teamView
    {
        public int id { get; set; }
        public string name { get; set; }
        public int department { get; set; }
        public int service { get; set; }
        public bool status { get; set; }

    }
}
