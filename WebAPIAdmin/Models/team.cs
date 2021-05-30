using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("team")]
    public class team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar")]
        public string name { get; set; }
        [Column("department", TypeName = "int")]
        public int department { get; set; }
        [Column("service", TypeName = "int")]
        public int service { get; set; }
        [Column("status", TypeName = "bit")]
        public bool status { get; set; }
    }
}
