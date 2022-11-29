using Sih.Application.Interfaces.Gestion;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Services.Gestion
{
    public class PaiementApplication : IPaiementApplication
    {
        private readonly IPaiementDomain _context;
        public PaiementApplication(IPaiementDomain context)
        {
            _context = context;
        }

        public Task<List<PaiementEntity>> Afficher_listeInsolvables(int idh)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaiementEntity>> Afficher_Versements_Pelerin(int idh, int id)
        {
            throw new NotImplementedException();
        }

        public async Task Ajouter(PaiementEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<PaiementEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<PaiementEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(PaiementEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(PaiementEntity entity)
        {
            await _context.Supprimer(entity);
        }

        public Task<string> VerifyPaiement(int id, int m)
        {
            /*
                    public async Task<InscriptionEntity> VerifyPaiement(int id)
                    {
                        //var verifie le niveau de paiement d'une inscription
                        //au moment de la mise à jour des paiements;

                        using var fabrique = new SIHDbContext(_OptionsBuilder);
                        var cout = fabrique.Hadjs
                            .First(h => h.Datefin.Year == DateTime.Now.Year)
                            .Cout;
                        var paiement =  fabrique.Inscriptions
                            .Include(p => p.Paiements)
                            .Where(i=>i.InscriptionEntityId==id)
                            .Select((p=>p.Paiements.Sum(s=>s.Montant))).FirstOrDefault();

                            if (cout - paiement == 0) //mise à jour du champ etatpaiement
                            {
                                return await VerifyPaiement(id);
                            }
                            else //
                            {
                                return await VerifyPaiement(id);
                            }



                    }

            */
            throw new NotImplementedException();
        }
    }
}
