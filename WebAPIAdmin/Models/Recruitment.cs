using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("Recruitment")]
    public class Recruitment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }
        [Column("first_name", TypeName = "varchar")]
        public string first_name { get; set; }
        [Column("last_name", TypeName = "varchar")]
        public string last_name { get; set; }
        [Column("age", TypeName = "int")]
        public int age { get; set; }
        [Column("weight", TypeName = "float")]
        public double weight { get; set; }
        [Column("height", TypeName = "float")]
        public double height { get; set; }
        [Column("phone", TypeName = "varchar")]
        public string phone { get; set; }
        [Column("email", TypeName = "varchar")]
        public string email { get; set; }
        [Column("address", TypeName = "varchar")]
        public string address { get; set; }
        [Column("cv", TypeName = "varchar")]
        public string cv { get; set; }
        [Column("achivement", TypeName = "varchar")]
        public string achivement { get; set; }
        [Column("introduce_yourself", TypeName = "varchar")]
        public string introduce_yourself { get; set; }
        [Column("status", TypeName = "bit")]
        public bool status { get; set; }
    }
}
