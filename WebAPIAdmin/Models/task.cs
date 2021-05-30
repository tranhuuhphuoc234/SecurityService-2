using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("task")]
    public class task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar")]
        public string name { get; set; }
        [Column("start_day", TypeName = "datetime")]
        public DateTime start_day { get; set; }
        [Column("end_day", TypeName = "datetime")]
        public DateTime end_day { get; set; }
        [Column("location", TypeName = "varchar")]
        public string location { get; set; }
        [Column("description", TypeName = "varchar")]
        public string descripttion { get; set; }
        [Column("request", TypeName = "int")]
        public int request { get; set; }
        [Column("team", TypeName = "int")]
        public int team { get; set; } 
        [Column("task_status", TypeName = "int")]
        public int task_status { get; set; }
    }
}
