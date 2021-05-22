using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("department")]
    public class department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="id")]
        public int id { get; set; }
        
        [Column("region",TypeName ="int")]
        public int region { get; set; }

        [Column("name",TypeName ="varchar")]
        [StringLength(200)]
        public string name { get; set; }

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }
    }
}
