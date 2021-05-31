using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("task_employee")]
    public class task_employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "id")]
        public int id { get; set; }

        [Column("task_main", TypeName = "int")]
        public int task_main { get; set; }

        [Column("employee", TypeName = "int")]
        public int employee { get; set; }

        [Column("description", TypeName = "varchar")]
        public string description { get; set; }

        [Column("task_name", TypeName = "varchar")]
        public string task_name { get; set; }

        [Column("start_time", TypeName = "varchar")]
        public string start_time { get; set; }

        [Column("end_time", TypeName = "varchar")]
        public string end_time { get; set; }

        [Column("task_status", TypeName = "int")]
        public int task_status { get; set; }

        [Column("start_day", TypeName = "DateTime")]
        public DateTime start_day { get; set; }

        [Column("end_day", TypeName = "DateTime")]
        public DateTime end_day { get; set; }
    }
}
