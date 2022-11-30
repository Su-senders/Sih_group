using Sih.Application.Interfaces.Gestion;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Services.Gestion
{
    public class VolApplication : IVolApplication
    {
        private readonly IVolDomain _context;
        public VolApplication(IVolDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(VolEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<VolEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<VolEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(VolEntity entity)
        {
            await _context.Modifier(entity);
        }

       
        public async Task Supprimer(VolEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
