using Microsoft.EntityFrameworkCore;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Persistence.Configurations;

namespace Sih.Persistence.Repositories.Gestion
{
   
    public class VoyageRepository : GenericRepository<VoyageEntity>, IVoyageDomain
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public VoyageRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }
        //public new async Task<List<VoyageEntity>> GetAll()
        //{
        //    using var fabrique = new SihDbContext(_OptionsBuilder);

        //    return await fabrique.Voyages
        //                    .Include(e => e.u)
        //                    .Include(h => h.Hadj)
        //                    .Include(u => u.Pelerin)
        //                    .ToListAsync();
        //}

    }
}
