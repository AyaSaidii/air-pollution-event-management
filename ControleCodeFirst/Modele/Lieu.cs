using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
     class Lieu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("ville")]
        [MaxLength(20)]
        public string ville { get; set; }
        [Required]
        [Column("adresse")]
        [MaxLength(20)]
        public string adresse { get; set; }
      //  public virtual List<PollutionData> PollutionData { get; set; }
       

        public Lieu()
        {
        }

        public Lieu(string adresse, string ville)
        {
            this.adresse = adresse;
            this.ville = ville;
        }
    }
}
