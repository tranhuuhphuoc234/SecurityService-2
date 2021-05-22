using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("client")]
    public class client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
    
        [Column("name",TypeName ="varchar")]
        [StringLength(200)]
        public string name { get; set; }

        [Column("phone",TypeName ="varchar")]
        [StringLength(20)]
        public string phone { get; set; }

        [Column("email",TypeName ="varchar")]
        [StringLength(300)]
        public string email { get; set; }

        [Column("address", TypeName = "varchar")]
        [StringLength(300)]
        public string address { get; set; }

        [Column("employee",TypeName ="int")]
        public int employee { get; set; }

   

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }


    }
}
