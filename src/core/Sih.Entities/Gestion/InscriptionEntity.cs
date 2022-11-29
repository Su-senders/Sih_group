using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Sih.Entities.Enums.MesEnums;

namespace Sih.Entities.Gestion
{
    public class InscriptionEntity
    {
        [Key]
        public int InscriptionEntityId { get; set; }
        [Display(Name = "Pilgrim")]
        public int UsagerEntityId { get; set; }
        [Display(Name = "Edition")]
        public int HadjEntityId { get; set; }
        [Display(Name = "Guide")]
        public int EncadreurEntityId { get; set; }
        [Display(Name = "Code Inscription")]
        public string Code { get; set; }
        public string Standing { get; set; }
        [Display(Name = "Payment Status")]
        public Etat_Paiement Etatpaiement { get; set; }//etat de paiement
        [Display(Name = "Treatment Status")]
        public Etat_Traitement Etat { get; set; }//status du traitement
        [Required, Display(Name = "Resgistration Date")]
        public DateTime DateIns { get; set; }
        // public Niveau_Paiement  etatpaiement { get; set; }
        public virtual ICollection<PaiementEntity> Paiements { get; set; }
        // public virtual ICollection<TraitementEntity> Traitements { get; set; }
        public virtual HadjEntity Hadj { get; set; }
        public virtual UsagerEntity Pelerin { get; set; }
        public virtual EncadreurEntity Encadreur { get; set; }
        public virtual ICollection<PieceJointesEntity> PiecesJointes { get; set; }
    }
}
