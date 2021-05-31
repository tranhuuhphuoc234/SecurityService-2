using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class taskView
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start_day { get; set; }
        public DateTime end_day { get; set; }
        public string location { get; set; }
        public string descripttion { get; set; }
        public int request { get; set; }
        public int team { get; set; }
        public int task_status { get; set; }
        public string name_team { get; set; }
        public string name_client { get; set; }
        public string name_service { get; set; }
        public string name_task_status { get; set; }
    }
}
