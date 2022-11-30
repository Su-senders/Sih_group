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
    public class VoyageApplication : IVoyageApplication
    {
        private readonly IVoyageDomain _context;
        private readonly IVolDomain _contextv;
        private readonly IInscriptionDomain _contexti;
        public VoyageApplication(IVoyageDomain context, IVolDomain contextv
            ,IInscriptionDomain contexti)
        {
            _context = context;
            _contextv = contextv;
            _contexti = contexti;
        }
        public async Task Ajouter(VoyageEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<VoyageEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<VoyageEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(VoyageEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(VoyageEntity entity)
        {
            await _context.Supprimer(entity);
        }
        public Task<string> Remplir_vol(int id, int idv, int nbre, Direction sens)
        {
            //il s'agit de prendre tous les pelerins
            //non embarqués qui ont pour encadreur id
            // jusqu'au nombre indiqué.
            //il faut au préalable vérifier les places disponibles.
            int capacite=_contextv.GetById(idv).Result.Capacite;
            IEnumerable<InscriptionEntity> inscriptions;
            if (capacite >= nbre)
            {
                if (sens==Direction.Aller)
                {
                     inscriptions = _contexti.GetAll()
                                                        .Result
                                                        .Where(i => (i.Etat == Etat_Traitement.Visa)
                                                        && i.EncadreurEntityId == id);
               
                    for (int i = 1; i < nbre; i++)
                    {
                        InscriptionEntity entity = inscriptions.First(i=>i.Etat!=Etat_Traitement.VolAller);
                        VoyageEntity voyage = new();
                        voyage.UsagerEntityId = entity.UsagerEntityId;
                        voyage.VolEntityId = idv;
                        _context.Ajouter(voyage);

                            entity.Etat = Etat_Traitement.VolAller;
                            _contexti.Modifier(entity);

                            //entity.Etat = Etat_Traitement.VolRetour;
                            //_contexti.Modifier(entity);
                    }
                    
                }
                else
                {
                    inscriptions = _contexti.GetAll()
                                                            .Result
                                                            .Where(i => (i.Etat == Etat_Traitement.VolAller)
                                                            && i.EncadreurEntityId == id);
                    for (int i = 1; i < nbre; i++)
                    {
                        InscriptionEntity entity = inscriptions.First(i => i.Etat != Etat_Traitement.VolRetour);
                        VoyageEntity voyage = new();
                        voyage.UsagerEntityId = entity.UsagerEntityId;
                        voyage.VolEntityId = idv;
                        _context.Ajouter(voyage);
                        entity.Etat = Etat_Traitement.VolRetour;
                        _contexti.Modifier(entity);
                    }
                }
                return Task.FromResult("Places reservées pour la liste des pèlerins.");
            }
            else
            {
                return Task.FromResult("Places non disponible");
            }
        }
    }
}
