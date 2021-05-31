using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAdmin.Models;

namespace WebAPIUser.Models.Context
{
    public class Security_ServiceContext: DbContext
    {
        public DbSet<about_us> get_about_us { get; set; }
        public DbSet<about_us_employee> get_about_us_employee { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<feedback> feedbacks { get; set; }
        public DbSet<grade> grades { get; set; }
        public DbSet<image> images { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<orderdetail> orderdetails { get; set; }
        public DbSet<region> regions { get; set; }
        public DbSet<service> services { get; set; }
        public DbSet<request> requests { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<speciality> specialities { get; set; }
        public DbSet<trainning> trainnings { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }
        public DbSet<admin> admin { get; set; }
        public DbSet<task> tasks { get; set; }
        public DbSet<task_status> task_Statuses { get; set; }
        public DbSet<task_employee> task_Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=115.73.214.162,1433;Initial Catalog=Security_Service;User ID=phuoc;Password=123321@");
        }

        public DbSet<WebAPIAdmin.Models.team> team { get; set; }
    }
}
