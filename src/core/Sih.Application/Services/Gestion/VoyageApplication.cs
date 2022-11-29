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
    public class VoyageApplication : IVoyageApplication
    {
        private readonly IVoyageDomain _context;
        public VoyageApplication(IVoyageDomain context)
        {
            _context = context;
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
    }
}
