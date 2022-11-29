using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;

namespace Sih.Domain.Interfaces.Gestion
{
    public interface IInscriptionDomain: IGenericDomain<InscriptionEntity>
    {
        //////liste de tous les futures pelerins inscrits
        ////Task<List<UsagerEntity>> Extraire_donnees_Badges(int id);
        ////// Task<InscriptionEntity> PositionDossier(string PassportN);
        ////Task<List<UsagerEntity>> Afficher_ListPelerins_inscrits(int idh);
        //////liste de tous les futures pelerins inscrits pour un encadreur
        ////Task<List<UsagerEntity>> Afficher_ListPelerins_inscrits_encadreur(int idh, int? ide);
    }
}
