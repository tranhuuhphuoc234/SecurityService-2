using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models.View
{
    public class feedbackView
    {
        public int id { get; set; }

        public string subject { get; set; }

        public string detail { get; set; }

        public int client { get; set; }

        public bool status { get; set; }

        public string name { get; set; }
    }
}
