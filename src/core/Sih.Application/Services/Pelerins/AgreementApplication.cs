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
    public class AgreementApplication : IAgreementApplication
    {
        private readonly IAgreementDomain _context;
        public AgreementApplication(IAgreementDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(AgreementEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<AgreementEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<AgreementEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(AgreementEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(AgreementEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
