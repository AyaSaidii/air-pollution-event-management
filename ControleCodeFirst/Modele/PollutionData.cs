using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    [Table("PollutionDatas", Schema = "dbo")]

    class PollutionData
    {
        private string adresse;

        public PollutionData()
        {
        }

        public PollutionData(DateTime date, string adresse)
        {
            Date = date;
            this.adresse = adresse;
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("NivPollution")]
        public string NivPollution { get; set; }
    }
}
