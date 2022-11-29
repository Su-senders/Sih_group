using Sih.Entities.Localisation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Gestion
{
    public class VolEntity
    {
        [Key]
        public int VolEntityId { get; set; }
        public int Numvol { get; set; }
        public int Capacite { get; set; }
        public string Direction { get; set; }
        public DateTime Datedepart { get; set; }
        public int VilleId { get; set; }//ville de départ
        public virtual VilleEntity VilleDepart { get; set; }
    }
}
