using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("order")]
    public class order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }

        [Column("discount",TypeName ="int")]
        public int discount { get; set; }
        
        [Column("total",TypeName ="float")]
        public double total { get; set; }

        [Column("client",TypeName ="int")]
        public int client { get; set; }

        [Column("date",TypeName ="date")]
        public DateTime date { get; set; }

    }
}
