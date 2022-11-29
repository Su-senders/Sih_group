using Microsoft.EntityFrameworkCore;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Persistence.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sih.Persistence.Repositories.Gestion
{
    public class InscriptionRepository:GenericRepository<InscriptionEntity>,IInscriptionDomain
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public InscriptionRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }


        public new async Task<List<InscriptionEntity>> GetAll()
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Inscriptions
                            .Include(e => e.Encadreur)
                            .Include(h => h.Hadj)
                            .Include(u => u.Pelerin)
                            .ToListAsync();
        }


        public new async Task<InscriptionEntity> GetById(int Id)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Inscriptions
                            .Include(e => e.Encadreur)
                            .Include(h => h.Hadj)
                            .Include(p => p.Pelerin)
                            .FirstOrDefaultAsync(m => m.InscriptionEntityId == Id);
        }
    }
}
