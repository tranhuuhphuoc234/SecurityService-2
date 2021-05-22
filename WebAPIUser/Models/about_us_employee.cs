using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("about_us_employee")]
    public class about_us_employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }

        [Column("name",TypeName ="varchar")]
        [StringLength(200)]
        public string name { get; set; }
    
        [Column("birthday",TypeName ="varchar")]
        [StringLength(200)]
        public string birthday { get; set; }
        
        [Column("age",TypeName ="int")]
        public int age { get; set; }

        [Column("img",TypeName ="varchar")]
        [StringLength(500)]
        public string img { get; set; }
    
        [Column("story",TypeName ="varchar")]
        [StringLength(3000)]
        public string story { get; set; }

        [Column("achivement",TypeName ="varchar")]
        [StringLength(3000)]
        public string achivement { get; set; }

        [Column("role",TypeName ="varchar")]
        [StringLength(50)]
        public string role { get; set; }

    }

}
