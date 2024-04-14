using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("CherchPollutionEvents", Schema = "dbo")]
    internal class CherchPollutionEvent
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Column("solution")]
        public string solution { get; set; }


        [ForeignKey("ChercheurF")]
        public int ChercheurId { get; set; }
        public virtual Chercheur ChercheurF { get; set; }

        // Clé étrangère pour l'événement de pollution

        [ForeignKey("PollutEventF")]
        public int PollutEventId { get; set; }
        public virtual PollutionEvenement PollutEventF { get; set; }


    }
}
