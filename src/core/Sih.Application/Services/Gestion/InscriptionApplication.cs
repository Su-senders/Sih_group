using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sih.Application.Interfaces.Gestion;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using static Sih.Entities.Enums.MesEnums;

namespace Sih.Application.Services.Gestion
{
    public class InscriptionApplication : IInscriptionApplication
    {
        private readonly IInscriptionDomain _context;
        public InscriptionApplication(IInscriptionDomain context)
        {
            _context = context;
        }

        public Task<IEnumerable<UsagerEntity>> Afficher_ListPelerins_inscrits(int idh)
        {
            IEnumerable<UsagerEntity> req = _context.GetAll().Result
                .Where(l => (l.Etatpaiement == Etat_Paiement.Solde) 
                && (l.Hadj.Datefin.Year == DateTime.Now.Year)).Select(p=>p.Pelerin);

            return Task.FromResult(req);
        }

        public Task<IEnumerable<UsagerEntity>> Afficher_ListPelerins_inscrits_encadreur(int? idh, int ide)
        {
            IEnumerable<UsagerEntity> req;
                if (idh==0)
                {
                    req = _context.GetAll().Result
                                           .Where(l => (l.Etatpaiement == Etat_Paiement.Solde)
                                            && (l.Hadj.Datefin.Year == DateTime.Now.Year)
                                            && (l.EncadreurEntityId == ide))
                                            .Select(p => p.Pelerin);
                    return Task.FromResult(req);
                }
                else
                {
                    req = _context.GetAll().Result
                                           .Where(l => (l.Etatpaiement == Etat_Paiement.Solde)
                                            && (l.Hadj.Datefin.Year == DateTime.Now.Year)
                                            && (l.EncadreurEntityId == ide))
                                            .Select(p => p.Pelerin);
                    return Task.FromResult(req);
                }
        }

        public async Task Ajouter(InscriptionEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public Task<IEnumerable<UsagerEntity>> Extraire_donnees_Badges(int id)
        {
            IEnumerable<UsagerEntity> req = _context.GetAll().Result
                                            .Where(l => (l.Etat == Etat_Traitement.Visa 
                                            || l.Etat==Etat_Traitement.VolAller)
                                             && (l.Hadj.HadjEntityId == id))
                                             .Select(p => p.Pelerin);
            return Task.FromResult(req);
        }

        public async Task<List<InscriptionEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<InscriptionEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(InscriptionEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(InscriptionEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
