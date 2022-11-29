using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Entities.Pelerins
{
    public class AgreementEntity
    {
        [Key]
        public int AgreementEntityId { get; set; }
        [Display(Name = "Date de début"), DataType(DataType.Date)]
        public DateTime Datedebut { get; set; }
        [Display(Name = "Date de fin"), DataType(DataType.Date)]
        public DateTime Datefin { get; set; }
        public int EncadreurEntityId { get; set; }
        [Display(Name="Decision Number")]
        public string Numero { get; set; }
        [Display(Name = "Zone of Action")]
        public string zone { get; set; }
        public virtual EncadreurEntity Encadreur { get; set; }
    }
}
