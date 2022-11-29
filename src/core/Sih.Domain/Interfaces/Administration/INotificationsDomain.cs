using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Domain.Interfaces.Administration
{
    public interface INotificationsDomain : IGenericDomain<NotificationsEntity>
    {
        Task<List<NotificationsEntity>> GetUserNotifications(string userId);
    }
}
