using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("grade")]
    public class grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }

        [Column("name", TypeName = "varchar")]
        [StringLength(200)]
        public string name { get; set; }

        [Column("status", TypeName = "bit")]
        public bool status { get; set; }

    }
}
