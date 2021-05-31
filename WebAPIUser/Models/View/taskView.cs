using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models.View
{
    public class taskView
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start_day { get; set; }
        public DateTime end_day { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public int request { get; set; }
        public int team { get; set; }
        public int task_status { get; set; }
        public string status_name { get; set; }
    }
}
