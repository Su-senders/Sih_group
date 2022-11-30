using Microsoft.EntityFrameworkCore;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Persistence.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sih.Persistence.Repositories.Gestion
{
    public class PaiementRepository : GenericRepository<PaiementEntity>, IPaiementDomain
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public PaiementRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }


        public new async Task<List<PaiementEntity>> GetAll()
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Paiements
                            .Include(i => i.Inscription)
                            .ThenInclude(i=>i.Pelerin)
                            .ToListAsync();
        }


        public new async Task<PaiementEntity> GetById(int Id)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Paiements
                            .Include(i => i.Inscription)
                            .FirstOrDefaultAsync(m => m.PaiementEntityId == Id);
        }
    }
}
