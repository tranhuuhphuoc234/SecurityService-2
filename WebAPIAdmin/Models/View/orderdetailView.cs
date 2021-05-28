using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class orderdetailView
    {
        public int id { get; set; }

        public int order { get; set; }
        public int service { get; set; }
        public int employee { get; set; }
        public string  name_client{ get; set; }
        public string name_employee { get; set; }
        public double total { get; set; }
        public DateTime date { get; set; }
        public string phone_client { get; set; }
        public string email_client { get; set; }
    }
}
