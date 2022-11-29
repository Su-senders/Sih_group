using Sih.Application.Interfaces.Pelerins;
using Sih.Domain.Interfaces.Pelerins;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Services.Pelerins
{
    public class SocieteApplication : ISocieteApplication
    {
        private readonly ISocieteDomain _context;
        public SocieteApplication(ISocieteDomain context)
        {
            _context = context;
        }
        public  Task Ajouter(SocieteEntity entity)
        {
            return   _context.Ajouter(entity);
        }

        public async Task<List<SocieteEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<SocieteEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(SocieteEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(SocieteEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
