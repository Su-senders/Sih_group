using Sih.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Domain.Interfaces.Gestion
{
    public interface IPaiementDomain:IGenericDomain<PaiementEntity>
    {
        ////Task<string> VerifyPaiement(int id, int m);
        ////Task<List<PaiementEntity>> Afficher_listeInsolvables(int idh);
        ////Task<List<PaiementEntity>> Afficher_Versements_Pelerin(int idh, int id);
    }
}
