using Sih.Application.Interfaces.Administration;
using Sih.Domain.Interfaces.Administration;
using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Services.Administration
{
    public class NotificationsApplication : INotificationsApplication
    {
        private readonly INotificationsDomain _context;
        public NotificationsApplication(INotificationsDomain context)
        {
            _context = context;
        }

        public async Task Ajouter(NotificationsEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<NotificationsEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<NotificationsEntity> GetById(int Id)
        {
            if (Id == 0)
            {
                return null;
            }

            return await _context.GetById(Id);
        }

        public async Task<List<NotificationsEntity>> GetUserNotifications(string userId)
        {
            return await _context.GetUserNotifications(userId);
        }

        public async Task Modifier(NotificationsEntity entity)
        {

            await _context.Modifier(entity);
        }

        public async Task Supprimer(NotificationsEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
