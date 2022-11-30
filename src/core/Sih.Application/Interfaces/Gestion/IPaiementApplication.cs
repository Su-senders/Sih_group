using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Interfaces.Gestion
{
    public interface IPaiementApplication:IGenericApplication<PaiementEntity>
    {
        Task<string> VerifyPaiement(int id);
        Task<IEnumerable<UsagerEntity>> Afficher_listeInsolvables(int idh);
        Task<IEnumerable<PaiementEntity>> Afficher_Versements_Pelerin(int idh, int id);
    }
}
