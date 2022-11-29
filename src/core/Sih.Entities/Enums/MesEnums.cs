namespace Sih.Entities.Enums
{
    public class MesEnums
    {
        public enum Etat_Paiement
        {
            Solde,
            incomplet
        }
        public enum Etat_Traitement
        {
            Enregister,
            MiNAT,
            Bank,
            Visa,
            VolAller,
            VolRetour
        }
        public enum Roles
        {
            SuperAdmin,
            CommonUser,
            AdminIdentity,
            AdminRoles,
            AdminBases
        }
    }
}
