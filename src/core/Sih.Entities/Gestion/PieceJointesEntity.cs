using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Gestion
{
    public class PieceJointesEntity
    {
        [Key]
        public int PieceJointesEntityId { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public long FileSize { get; set; }
        public byte[] FileNumerise { get; set; }
        public bool Qualite { get; set; } = false;
        public int InscriptionEntityId { get; set; }
        public int PiecesTypeEntityId { get; set; }
        public virtual InscriptionEntity Inscription { get; set; }
        public virtual PiecesTypeEntity PieceType { get; set; }
    }
}
