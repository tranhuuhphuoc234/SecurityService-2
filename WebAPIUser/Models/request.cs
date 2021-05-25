using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("request")]
    public class request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }

        [Column("service", TypeName = "varchar")]
        public string service { get; set; }

        [Column("message",TypeName ="varchar")]
        [StringLength(3000)]
        public string message { get; set; }

        [Column("client",TypeName ="int")]
        public int client { get; set; }

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }

    }
}
