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
    public class HadjApplication : IHadjApplication
    {
        private readonly IHadjDomain _context;
        public HadjApplication(IHadjDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(HadjEntity entity)
        {
           await  _context.Ajouter(entity); 
        }

        public async Task<List<HadjEntity>> GetAll()
        {
           return await _context.GetAll();
        }

        public async Task<HadjEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(HadjEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(HadjEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
