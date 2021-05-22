using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("about_us")]
    public class about_us
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
        
        [Column("where",TypeName ="varchar")]
        [StringLength(3000)]
        public string where { get; set; }

        [Column("when", TypeName = "varchar")]
        [StringLength(3000)]
        public string when { get; set; }

        [Column("how", TypeName = "varchar")]
        [StringLength(3000)]
        public string how { get; set; }


    }
}
