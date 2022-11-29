using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Localisation
{
    public class DepartureTownEntity
    {
        [Key]
        public int DepartureTownEntityId { get; set; }
        public int UsagerEntityId { get; set; }
        public int HadjEntityId { get; set; }
        public int VilleEntityId { get; set; }
        public virtual VilleEntity VilleDepart { get; set; }
    }
}
