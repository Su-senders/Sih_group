using Sih.Application.Interfaces.Localisation;
using Sih.Domain.Interfaces.Localisation;
using Sih.Entities.Localisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Services.Localisation
{
    public class DepartureTownApplication : IDepartureTownApplication
    {
        private readonly IDepartureTownDomain _context;
        public DepartureTownApplication(IDepartureTownDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(DepartureTownEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<DepartureTownEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<DepartureTownEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(DepartureTownEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(DepartureTownEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
