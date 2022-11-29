using Microsoft.AspNetCore.Mvc;
using Sih.Application.Interfaces.Administration;
using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class OfficeController : Controller
    {
        private readonly INotificationsApplication _contextJournal;

        //Declaration du journal
        private readonly NotificationsEntity msg = new NotificationsEntity();

        public OfficeController(INotificationsApplication contextNotif)
        {
            _contextJournal = contextNotif;
        }

        public async Task<IActionResult> Index()
        {
            /* Journalisation */
            msg.Titre = "Back Office";
            msg.Information = "Accès au back office par l'utilisateur " + User.Identity.Name;
            msg.UserEmail = User.Identity.Name;
            await _contextJournal.Ajouter(msg);
            /* Journalisation */

            return View();
        }
    }
}
