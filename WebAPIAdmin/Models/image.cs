using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("image")]
    public class image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }

        [Column("path", TypeName = "varchar")]
        [StringLength(300)]
        public string path { get; set; }

        [Column("employee", TypeName = "int")]
        public int employee { get; set; }

    }
}
