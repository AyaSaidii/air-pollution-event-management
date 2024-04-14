using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("Login", Schema = "dbo")]
    class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        [MaxLength(20)]
        public string username { get; set; }
        [Required]
        [Column("pass")]
        [MaxLength(20)]
        public string pass { get; set; }
        public Login() { }
    }
}
