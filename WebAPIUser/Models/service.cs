using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("service")]
    public class service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }

        [Column("name",TypeName ="varchar")]
        [StringLength(300)]
        public string name { get; set; }

        [Column("price",TypeName ="float")]
        public double price { get; set; }

        [Column("status",TypeName ="status")]
        public bool status { get; set; }

        [Column("description",TypeName ="varchar")]
        [StringLength(5000)]
        public string description { get; set; }

    }
}
