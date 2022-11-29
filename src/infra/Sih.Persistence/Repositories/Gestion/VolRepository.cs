using Microsoft.EntityFrameworkCore;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Persistence.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sih.Persistence.Repositories.Gestion
{
    public class VolRepository : GenericRepository<VolEntity>, IVolDomain
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public VolRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }


        public new async Task<List<VolEntity>> GetAll()
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Vols
                            .Include(v => v.VilleDepart)
                            .ToListAsync();
        }


        public new async Task<VolEntity> GetById(int Id)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Vols
                            .Include(v => v.VilleDepart)
                            .FirstOrDefaultAsync(m => m.VolEntityId == Id);
        }

    }
}
