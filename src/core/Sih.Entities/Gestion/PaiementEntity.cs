using System;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Gestion
{
    public class PaiementEntity
    {
        [Key]
        public int PaiementEntityId { get; set; }
        [Required, Display(Name = "Date de Versement")]
        public DateTime Dateversement { get; set; }
        public int Montant { get; set; }
        public int InscriptionEntityId { get; set; }
        public virtual InscriptionEntity Inscription { get; set; }

    }
}
