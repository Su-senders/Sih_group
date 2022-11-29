using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Interfaces.Administration
{
    public interface INotificationsApplication : IGenericApplication<NotificationsEntity>
    {
        Task<List<NotificationsEntity>> GetUserNotifications(string userId);
    }
}
