using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("Evenements", Schema = "dbo")]

    class Evenement
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("date")]
        public DateTime date { get; set; }

    }
}
