using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Administration;
using Sih.Entities.Administration;
using Sih.Web.Areas.Administration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotificationsApplication _contextJournal;
        //Declaration du journal
        private readonly NotificationsEntity msg = new NotificationsEntity();

        public UserRolesController(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager,
            INotificationsApplication contextNotif)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _contextJournal = contextNotif;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (UserEntity user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.NomPrenom = user.NomPrenom;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            /* Journalisation */
            msg.Titre = "Profils utilisateurs";
            msg.Information = "Consultation de la liste des profils par l'utilisateur " + User.Identity.Name;
            msg.UserEmail = User.Identity.Name;
            await _contextJournal.Ajouter(msg);
            /* Journalisation */


            return View(userRolesViewModel);
        }

        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;

            var model = new List<ManageUserRolesViewModel>();

            //
            //Avec SqlServer Express 
            //
            var thisViewModel = new UserRolesViewModel();
            thisViewModel.Roles = await GetUserRoles(user);

            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                string _trouve = thisViewModel.Roles.FirstOrDefault(v => v.Equals(role.Name));
                if (_trouve == role.Name)
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }

            /* Journalisation */
            msg.Titre = "Profils utilisateurs";
            msg.Information = "Accès à l'interface de gestion du profil de l'utilisateur  " + user.Email + " par l'utilisateur " + User.Identity.Name;
            msg.UserEmail = User.Identity.Name;
            await _contextJournal.Ajouter(msg);
            /* Journalisation */


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");

                /* Journalisation */
                msg.Titre = "Profils utilisateurs";
                msg.UserEmail = User.Identity.Name;

                msg.Information = "Echec de mise à jour des rôles de l'utilisateur  " + user.Email + " par l'utilisateur " + User.Identity.Name;
                await _contextJournal.Ajouter(msg);
                /* Journalisation */

                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");

                /* Journalisation */
                msg.Titre = "Profils utilisateurs";
                msg.UserEmail = User.Identity.Name;

                msg.Information = "Echec de mise à jour des rôles de l'utilisateur  " + user.Email + " par l'utilisateur " + User.Identity.Name;
                await _contextJournal.Ajouter(msg);
                /* Journalisation */

                return View(model);
            }


            /* Journalisation */
            msg.Titre = "Profils utilisateurs";
            msg.UserEmail = User.Identity.Name;

            msg.Information = "Mise à jour des rôles de l'utilisateur  " + user.Email + " par l'utilisateur " + User.Identity.Name;
            await _contextJournal.Ajouter(msg);
            /* Journalisation */

            return RedirectToAction("Index");
        }
        private async Task<List<string>> GetUserRoles(UserEntity user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
