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
    public class RegionApplication : IRegionApplication
    {
        private readonly IRegionDomain _context;
        public RegionApplication(IRegionDomain context)
        {
            _context = context;
        }
        public Task Ajouter(RegionEntity entity)
        {
            return _context.Ajouter(entity);
        }

        public async Task<List<RegionEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<RegionEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(RegionEntity entity)
        {
             await _context.Modifier(entity);
        }

        public async Task Supprimer(RegionEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
