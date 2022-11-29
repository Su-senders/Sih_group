using Sih.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Entities.Pelerins
{
    public class HadjEntity
    {
        [Key]
        public int HadjEntityId { get; set; }
        [Required]
        public string Edition{ get; set; }
        [Required, DataType(DataType.Date),Display(Name ="Date de Début")]
        public DateTime Datedebut { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Date de Début")]
        public DateTime Datefin { get; set; }
        public int Quota { get; set; }
        [Display(Name ="Coût")]
        public long Cout { get; set; }
        public virtual ICollection<InscriptionEntity> Inscriptions { get; set; }
    }
}
