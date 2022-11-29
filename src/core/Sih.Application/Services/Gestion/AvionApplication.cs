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
    public class AvionApplication:IAvionApplication
    {
        private readonly IAvionDomain _context;
        public AvionApplication(IAvionDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(AvionEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<AvionEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<AvionEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(AvionEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(AvionEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
