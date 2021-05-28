using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class requestView
    {
        public int id { get; set; }
        public string service { get; set; }
        public string message { get; set; }
        public int client { get; set; }
        public bool status { get; set; }
        public string client_name{ get; set; }
        public string client_phone { get; set; }
        public string client_email { get; set; }
        public string client_address { get; set; }
        public int employee { get; set; }
        public bool client_status { get; set; }

    }
}
