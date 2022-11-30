using Sih.Application.Interfaces.Gestion;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sih.Entities.Enums.MesEnums;

namespace Sih.Application.Services.Gestion
{
    public class PaiementApplication : IPaiementApplication
    {
        private readonly IPaiementDomain _context;
        private readonly IInscriptionDomain _contexti;
        public PaiementApplication(IPaiementDomain context,IInscriptionDomain contexti)
        {
            _context = context;
            _contexti = contexti;
        }

        public Task<IEnumerable<UsagerEntity>> Afficher_listeInsolvables(int idh)
        {
            IEnumerable<UsagerEntity> req;
           
                req = _context.GetAll().Result
                                       .Where(p => (p.Inscription.Etatpaiement 
                                       != Etat_Paiement.Solde)
                                        && (p.Inscription.HadjEntityId == idh))
                                        .Select(p => p.Inscription.Pelerin);
                return Task.FromResult(req);
            
        }

        public Task<IEnumerable<PaiementEntity>> Afficher_Versements_Pelerin(int idh, int id)
        {
            IEnumerable<PaiementEntity> req;
            req = _context.GetAll().Result
                                       .Where(p => (p.Inscription.Pelerin.UsagerEntityId == id)
                                        && (p.Inscription.HadjEntityId == idh));
            return Task.FromResult(req); //il faut envisager afficher
                                         //ceci comme une vue partielle
                                         //pour concerver le nom du pèlerin.
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

        public async   Task<string> VerifyPaiement(int id)
        {

            //verifie le niveau de paiement d'une inscription
            //au moment de la mise à jour des paiements;

            var paiements = _context.GetAll().Result;
                       long cout=paiements.First(h => h.Inscription.Hadj.Datefin.Year == DateTime.Now.Year)
                            .Inscription.Hadj.Cout;
                        long paiement =  paiements
                            .Where(i=>i.InscriptionEntityId==id)
                            .Select(s=>s.Montant).Sum();

                            if (cout - paiement == 0) //mise à jour du champ etatpaiement
                            {
                                InscriptionEntity inscription= await _contexti.GetById(id);
                                inscription.Etatpaiement = Etat_Paiement.Solde;
                                await _contexti.Modifier(inscription);
                                return "soldé";
                            }
                            else //
                            {
                                return "non soldé";
                            }



        }

    }
}

