using Microsoft.EntityFrameworkCore;
using Sih.Domain.Interfaces.Administration;
using Sih.Entities.Administration;
using Sih.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Persistence.Repositories.Administration
{
    public class NotificationsRepository : GenericRepository<NotificationsEntity>, INotificationsDomain
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public NotificationsRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }

        public async Task<List<NotificationsEntity>> GetUserNotifications(string userId)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            return await fabrique.Set<NotificationsEntity>().Where(i => i.UserEmail == userId).AsNoTracking().ToListAsync();
        }
    }
}
