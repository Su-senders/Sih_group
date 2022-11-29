using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Gestion
{
    public class AvionEntity
    {
        [Key]
        public int AvionEntityId { get; set; }
        public int Capacite { get; set; }
        public string NumAvion { get; set; }
    }
}
