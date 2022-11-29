using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Localisation
{
    public class VilleEntity
    {
        [Key]
        public int VilleEntityId { get; set; }
        [Display(Name ="Departure Town")]
        public string NomVille { get; set; }
        [Display(Name ="Belonging Region")]
        public int RegionEntityId { get; set; }
        public virtual RegionEntity Region { get; set; }
        public virtual ICollection<DepartureTownEntity> Departures { get; set; }

    }
}
