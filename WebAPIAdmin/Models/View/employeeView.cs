using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    public class employeeView
    {

        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public double weight { get; set; }

        public double height { get; set; }

       
        public string phone { get; set; }

    
        public string email { get; set; }

      
        public string address { get; set; }

        public string department { get; set; }

        public string role { get; set; }

        public string grade { get; set; }

        public string achivement { get; set; }

        public string speciality { get; set; }

        public double price { get; set; }

   
        public string aboutme { get; set; }

        public bool status { get; set; }
    }
}
