using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("PollutionEvenements", Schema = "dbo")]
     class PollutionEvenement : Evenement
    {
        [Required]
        [MaxLength(150)]
        [Column("nom")]
        public string nom { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("cause")]

        public string cause { get; set; }

       

        // Propriété de navigation (composition)
        //La propriété LieuId est une clé étrangère qui sera utilisée pour stocker
        //l'identifiant du Lieu associé à chaque PollutionEvenement.
        [ForeignKey("LieuF")]
         public int LieuId { get; set; }

       public virtual Lieu LieuF { get; set; }
        
        [ForeignKey("PollutionData")]
        public int DataId { get; set; }

       public virtual PollutionData PollutionData { get; set; }
      // public virtual ICollection<CherchPollutionEvent> chercheurpevents { get; set; }


        //liste virtuelchercheur


    }
}
