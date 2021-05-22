using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class billView
    {
        public int id { get; set; }
        public string service { get; set; }
        public int discount { get; set; }
        public string employee { get; set; }
        public string client { get; set; }
        public double total { get; set; }

        public DateTime date { get; set; }
    }
}
