using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Localisation
{
    public class RegionEntity
    {
        [Key]
        public int RegionEntityId { get; set; }
        [Display(Name = "Code of the Region")]
        public string CodeReg { get; set; }
        [Display(Name = "Region Name")]
        public string NomReg { get; set; }
        public virtual ICollection<VilleEntity> Villes { get; set; }
    }
}
