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

        public int id_department { get; set; }

        public string department { get; set; }

        public int id_role { get; set; }

        public string role { get; set; }

        public int id_garde { get; set; }

        public string grade { get; set; }

        public string achivement { get; set; }

        public int id_speciality { get; set; }

        public string speciality { get; set; }

        public double price { get; set; }

   
        public string aboutme { get; set; }

        public bool status { get; set; }

        public string usrname { get; set; }

        public string password { get; set; }

        public string image { get; set; }

        public int team { get; set; }

        public int id_region { get; set; }

    }
}
