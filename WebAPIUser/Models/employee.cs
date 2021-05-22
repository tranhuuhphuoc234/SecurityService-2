using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("employee")]
    public class employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
        
        [Column("name",TypeName ="varchar")]
        [StringLength(200)]
        public string name { get; set; }

        [Column("age",TypeName ="int")]
        public int age { get; set; }

        [Column("weight",TypeName ="float")]
        public double weight { get; set; }

        [Column("height",TypeName ="float")]
        public double height { get; set; }
    
        [Column("phone",TypeName ="varchar")]
        [StringLength(20)]
        public string phone { get; set; }

        [Column("email",TypeName ="varchar")]
        [StringLength(300)]
        public string email { get; set; }

        [Column("address",TypeName ="varchar")]
        [StringLength(500)]
        public string address { get; set; }

        [Column("department",TypeName ="int")]
        public int department { get; set; }

        [Column("role",TypeName ="int")]
        public int role { get; set; }

        [Column("grade",TypeName ="int")]
        public int grade { get; set; }

        [Column("achivement",TypeName ="varchar")]
        [StringLength(5000)]
        public string achivement { get; set; }
        
        [Column("speciality",TypeName ="int")]
        public int speciality { get; set; }

        [Column("price",TypeName ="float")]
        public double price { get; set; }

        [Column("aboutme",TypeName ="varchar")]
        [StringLength(3000)]
        public string aboutme { get; set; }

        [Column("usrname",TypeName ="varchar")]
        [StringLength(300)]
        public string usrname { get; set; }

        [Column("pwd",TypeName ="varchar")]
        [StringLength(500)]
        public string pwd { get; set; }
        
        [Column("status",TypeName ="bit")]
        public bool status { get; set; }
    }
}
