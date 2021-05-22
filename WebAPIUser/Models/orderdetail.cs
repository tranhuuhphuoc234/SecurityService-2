using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("orderdetail")]
    public class orderdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
        
        [Column("order",TypeName ="int")]
        public int order { get; set; }

        [Column("service",TypeName ="int")]
        public int service { get; set; }

        [Column("employee",TypeName ="int")]
        public int employee { get; set; }

    }
}
