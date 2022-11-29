using System;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Gestion
{
    public class VoyageEntity
    {
        [Key]
        public int VoyageEntityId { get; set; }
        public int VolEntityId { get; set; }
        public int UsagerEntityId { get; set; }
        public string Direction { get; set; }
        public DateTime Datedepart { get; set; }
    }
}
