using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sih.Application.Interfaces.Localisation;
using Sih.Domain.Interfaces.Localisation;
using Sih.Entities.Localisation;

namespace Sih.Application.Services.Localisation
{
    public class VilleApplication : IVilleApplication
    {
        private readonly IVilleDomain _context;
        public VilleApplication(IVilleDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(VilleEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<VilleEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<VilleEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(VilleEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(VilleEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
