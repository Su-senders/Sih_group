using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Localization;
using Sih.Entities.Administration;

namespace Sih.Web.Helper
{
    //
    // Résumé :
    //      Cette classe est une sorte de variable globale permettant entre autre de conserver
    //      l'id du poste de l'utilisateur connecté. si cet id vaut 0, alors l'utilisateur connecté
    //      n'est pas un personnel occupant actuellement un poste de travail ou alors sa session est encore active malgré le fait qu'il a
    //      antérieurement fermé le programme avant de le relancer.
    //
    // Propriété :
    //   GetPost:
    //     L'Id de l'utilisateur connecté.
    //
    // Utilisation :
    //     Recuppère l'Id du poste de l'utilisateur courrant au moment du login et la conserve
    //     jusqu'à la fermeture du programme
    public class VariableGlobale
    {
        private static IHtmlLocalizer<VariableGlobale> _localizer;
        public static UserManager<UserEntity> _userManager;
        public VariableGlobale(UserManager<UserEntity> userManager, IHtmlLocalizer<VariableGlobale> loc)
        {
            _localizer = loc;
            _userManager = userManager;
        }
        public static int GetPost { get; set; } = 0;
        public static string GetLanguage { get; set; }

        public static string GetPostMsg { get; } = "Erreur liée au poste de travail: veuillez vous déconnecter; puis reconnecter vous pour poursuivre";
        public static string GetPostMsgEn { get; } = "Error related to the workstation: please disconnect; then reconnect to continue";

        public static string GetInputFieldMsg { get; set; } = "Erreur...Veuillez saisir tous les champs";
        public static string GetInputFieldMsgEn { get; set; } = "Error ... please fill all the field";

        public static string GetExistEmaildMsg { get; } = "Erreur... Cet email/matricule est déjà attribué";
        public static string GetExistEmaildMsgEn { get; } = "Error ... This email/matricule is already assigned";

        public static string GetExistNumeroDemandeMsg { get; } = "Erreur... Ce numero est déjà attribué";
        public static string GetExistNumeroDemandeMsgEn { get; } = "Error... This number is already assigned";

        public static string GetEtatPieceJointedMsg { get; } = "Erreur? Attention!!! Cette demande ne présente pas toutes les pièces exigible!";
        public static string GetEtatPieceJointedMsgEn { get; } = "Error? Warning !!! This request does not include all the required documents!";

        public static string GetProcessingDeniedMsgIncomplete { get; } = "Erreur? Vous ne pouvez valider une demande qui a des pièces manquantes";
        public static string GetProcessingDeniedMsgIncompleteEn { get; } = "Error? You cannot validate a request that has missing parts";

        public static string GetProcessingDeniedMsgApprouve { get; } = "Erreur? Vous ne pouvez valider une demande dont toutes les pièces ne sont pas approuvées";
        public static string GetProcessingDeniedMsgApprouveEn { get; } = "Error? You cannot validate a request for which all the parts are not approved";
        public static string GetInputDeniedMsgApprouve { get; } = "Erreur? Veuillez enregistrer au préalable l'armurerie relative à ce promoteur";
        public static string GetInputDeniedMsgApprouveEn { get; } = "Erreur? Veuillez enregistrer au préalable l'armurerie relative à ce promoteur";

        public static string GetProcessingDeniedMsgMoralite { get; } = "Erreur? Vous ne pouvez valider la demande d'un usager dont la moralité n'est pas bonne";
        public static string GetProcessingDeniedMsgMoraliteEn { get; } = "Error? You cannot validate the request of a user whose morality is not good";

        public static string GetInconnuErrordMsg { get; } = "Erreur... cause inconnue";
        public static string GetInconnuErrordMsgEn { get; } = "Error ... cause unknown";

        public static string GetNoPieceJointeErrordMsg { get; } = "Erreur! cette demande n'a aucune pièce jointe: veuillez la completer";
        public static string GetNoPieceJointeErrordMsgEN { get; } = "Error! This request has no attachments: please complete it";

        public static string GetDemmandeFinaliseMsg { get; } = "Erreur! cette demande a déja été classé";
        public static string GetDemmandeFinaliseMsgEN { get; } = "Error! This request has already been filed";

        public static string GetDoublonMsg { get; } = "Erreur... Impossible d'ajouter un doublon";
        public static string GetDoublonMsgEn { get; } = "Error ... This name is already assigned";

        public static string GetDeleteMsg { get; } = "Erreur... action refusée, veuiller contacter les administreurs";
        public static string GetDeleteMsgEn { get; } = "Error ... action refusée, veuiller contacter les administreurs";

        public static string FnGetInputFieldMsg(string msg)
        {
            if (VariableGlobale.GetLanguage == "fr")
            {
                return msg;
            }
            else
            {
                return msg + "En";
            }
        }
    }
}
