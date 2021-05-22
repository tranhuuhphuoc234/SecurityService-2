using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("feedback")]
    public class feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }

        [Column("subject",TypeName ="varchar")]
        [StringLength(200)]
        public string subject { get; set; }
    
        [Column("detail",TypeName ="varchar")]
        [StringLength(3000)]
        public string detail { get; set; }

        [Column("client",TypeName ="int")]
        public int client { get; set; }

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }
    }
}
