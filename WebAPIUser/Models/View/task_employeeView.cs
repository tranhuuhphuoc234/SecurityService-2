using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models.View
{
    public class task_employeeView
    {
        public int id { get; set; }

        public int task_main { get; set; }

        public int employee { get; set; }

        public string description { get; set; }

        public string task_name { get; set; }

        public string start_time { get; set; }

        public string end_time { get; set; }

        public int task_status { get; set; }

        public DateTime start_day { get; set; }

        public DateTime end_day { get; set; }

        public string name_status { get; set; }
    }
}
