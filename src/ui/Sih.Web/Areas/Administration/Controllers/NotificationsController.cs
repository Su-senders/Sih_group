using Microsoft.AspNetCore.Mvc;
using Sih.Application.Interfaces.Administration;
using Sih.Entities.Administration;
using Sih.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class NotificationsController : Controller
    {
        private readonly INotificationsApplication _context;
        //Declaration du journal
        private readonly NotificationsEntity msg = new NotificationsEntity();

        public NotificationsController(INotificationsApplication context)
        {
            _context = context;
        }

        // GET: Sih/Zone
        public async Task<IActionResult> Index(int pg = 1)
        {
            var notifications = await _context.GetAll(); // obtention de la liste des zones


            // début --- initialisation des variables pour la pagination

            const int pageSize = 100; // nombre d'enregistrement à afficher par page

            if (pg < 1)
                pg = 1;

            int recsCount = notifications.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = notifications.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            // Fin  --- initialisation des variables pour la pagination

            /* Journalisation */
            msg.Titre = "Journal système";
            msg.Information = "Consultation du journal des opérations système par l'utilisateur " + User.Identity.Name;
            msg.UserEmail = User.Identity.Name;
            await _context.Ajouter(msg);
            /* Journalisation */

            return View(data);
        }


        // GET: NotificationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotificationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
