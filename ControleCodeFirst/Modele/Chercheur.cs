using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("Chercheurs", Schema = "dbo")]
    class Chercheur
    {
        [Key]
        [Column("ID")]
        public int ChercheurId { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("Nom")]
        public string Nom { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("Prenom")]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("Email")]
        //public virtual ICollection<CherchPollutionEvent> chercheurpevents { get; set; }

        public string Email { get; set; }

        public Chercheur()
        {
        }

        public Chercheur(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }
    }
}
