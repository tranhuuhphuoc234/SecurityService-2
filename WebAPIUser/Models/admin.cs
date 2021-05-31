using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("admin")]
    public class admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int id { get; set; }

        [Column("username", TypeName = "varchar")]
        [StringLength(30)]
        public string username { get; set; }

        [Column("password", TypeName = "varchar")]
        public string password { get; set; }
    }
}
