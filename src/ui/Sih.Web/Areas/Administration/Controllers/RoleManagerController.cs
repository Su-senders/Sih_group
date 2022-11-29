using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Administration;
using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "SuperAdmin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotificationsApplication _contextJournal;
        //Declaration du journal
        private readonly NotificationsEntity msg = new NotificationsEntity();

        public RoleManagerController(RoleManager<IdentityRole> roleManager,
            INotificationsApplication contextNotif)
        {
            _roleManager = roleManager;
            _contextJournal = contextNotif;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            /* Journalisation */
            msg.Titre = "Rôles utilisateurs";
            msg.Information = "Consultation de la liste des rôles  par l'utilisateur " + User.Identity.Name;
            msg.UserEmail = User.Identity.Name;
            await _contextJournal.Ajouter(msg);
            /* Journalisation */
            return View(roles);
        }

        [Authorize(Roles = "AdminRoles")]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
                /* Journalisation */
                msg.Titre = "Rôles utilisateurs";
                msg.Information = "Ajout d'un nouveau rôle en mode développement par l'utilisateur " + User.Identity.Name;
                msg.UserEmail = User.Identity.Name;
                await _contextJournal.Ajouter(msg);
                /* Journalisation */

            }
            return RedirectToAction("Index");
        }
    }
}
