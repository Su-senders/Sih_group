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
    public class EncadreurApplication : IEncadreurApplication
    {
        private readonly IEncadreurDomain _context;
        public EncadreurApplication(IEncadreurDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(EncadreurEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<EncadreurEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<EncadreurEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(EncadreurEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(EncadreurEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
