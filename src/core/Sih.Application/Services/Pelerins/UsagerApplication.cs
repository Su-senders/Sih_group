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
    public class UsagerApplication : IUsagerApplication

    {
        private readonly IUsagerDamain _context;
        public UsagerApplication(IUsagerDamain context)
        {
            _context = context;
        }
        public Task Ajouter(UsagerEntity entity)
        {
            return _context.Ajouter(entity);
        }

        public async Task<List<UsagerEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public Task<UsagerEntity> GetById(int Id)
        {
            return _context.GetById(Id);
        }

        public async Task Modifier(UsagerEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(UsagerEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
