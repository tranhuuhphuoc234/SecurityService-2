using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("reason_reject")]
    public class reason_reject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }

        [Column("id_task", TypeName = "int")]
        public int id_task { get; set; }

        [Column("reason", TypeName = "varchar")]
        [StringLength(8000)]
        public string reason { get; set; }

        [Column("status", TypeName = "bit")]
        public bool status { get; set; }
    }
}
