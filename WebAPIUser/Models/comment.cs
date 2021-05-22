using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("comment")]
    public class comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
    
        [Column("detail",TypeName ="varchar")]
        [StringLength(3000)]
        public string detail { get; set; }
        
        [Column("rate",TypeName ="int")]
        public int rate { get; set; }

        [Column("employee",TypeName ="int")]
        public int employee { get; set; }

        [Column("client", TypeName = "int")]
        public int client { get; set; }
    }
}
