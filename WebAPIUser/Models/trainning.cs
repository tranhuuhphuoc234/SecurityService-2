using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("trainning")]
    public class trainning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
        
        [Column("name",TypeName ="varchar")]
        [StringLength(200)]
        public string name { get; set; }

        [Column("detail",TypeName ="varchar")]
        [StringLength(3000)]
        public string detail { get; set; }
        
        [Column("duration",TypeName ="varchar")]
        [StringLength(50)]
        public string duration { get; set; }

        [Column("trainer",TypeName ="varchar")]
        [StringLength(50)]
        public string trainer { get; set; }

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }

    }
}
