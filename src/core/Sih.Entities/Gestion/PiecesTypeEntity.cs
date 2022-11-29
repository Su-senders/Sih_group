using System.Collections.Generic;

namespace Sih.Entities.Gestion
{
    public class PiecesTypeEntity
    {
        public int PiecesTypeEntityId { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<PieceJointesEntity> PieceJointes { get; set; }
    }
}
