using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    public class departmentView
    {

        public int id { get; set; }
        public string region { get; set; }

       
        public string name { get; set; }

        public bool status { get; set; }
        public string name_region { get; set; }
    }
}
