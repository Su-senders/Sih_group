using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sih.Application.Interfaces.Administration;
using Sih.Entities.Administration;
using Sih.Web.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly INotificationsApplication _contextJournal;
        //Declaration du journal
        //private readonly NotificationsEntity msg = new NotificationsEntity();
        private IEnumerable<UserEntity> _Utilisateurs;

        public UserManagerController(UserManager<UserEntity> userManager, /*RoleManager<IdentityRole> roleManager,
            INotificationsApplication contextNotif,*/ IEnumerable<UserEntity> Utilisateurs)
        {
            //_roleManager = roleManager;
            _userManager = userManager;
            //_contextJournal = contextNotif;
            _Utilisateurs = Utilisateurs;
        }

        public IActionResult Index()
        {
            _Utilisateurs = _userManager.Users.OrderBy(l => l.UserName);

            return View(_Utilisateurs);
        }
        public ActionResult Delete(string id)
        {
            var dbEntry = _userManager.FindByIdAsync(id);

            if (dbEntry == null)
            {
                return RedirectToAction("Index");
            }

            if (dbEntry.Result.UserName == User.Identity.Name)
            {
                TempData["_StatusMessage"] = string.Format(" l'utilisateur << {0} >> ne peut s'auto supprimé!!!", dbEntry.Result.UserName);
                return RedirectToAction("Index");
            }

            var result = _userManager.DeleteAsync(dbEntry.Result);

            TempData["_StatusMessage"] = string.Format(" l'utilisateur << {0} >> a été supprimé", dbEntry.Result.UserName);
            return RedirectToAction("Index");
        }

        //
        //
        // GET: Utilisateur/Create
        public ActionResult Create(UtilisateurModelVue modelUtilisateur)
        {
            return View(modelUtilisateur);
        }

        // POST: Utilisateur/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]  // Afin de déjouer les attaques par sur-validation
        public async Task<ActionResult> CreatePost(UtilisateurModelVue modelUtilisateur)
        {
            if (ModelState.IsValid)
            {
                modelUtilisateur.Utilisateur = await _userManager.FindByEmailAsync(modelUtilisateur.Email);

                if (modelUtilisateur.Utilisateur == null)
                {
                    UserEntity Utilisateur = new UserEntity();
                    //----------------------------
                    Utilisateur.UserName = modelUtilisateur.Email;
                    Utilisateur.PhoneNumber = modelUtilisateur.PhoneNumber;
                    Utilisateur.Email = modelUtilisateur.Email;
                    Utilisateur.NomPrenom = modelUtilisateur.UserName;

                    //----------------------------
                    var result = await _userManager.CreateAsync(Utilisateur, modelUtilisateur.Password);

                    if (result.Succeeded)
                    {
                        TempData["_StatusMessage"] = string.Format("{0} as été ajouter avec succès", modelUtilisateur.UserName);
                    }
                    else
                    {
                        int errorCount = result.Errors.Count();
                        TempData["_StatusMessage"] = string.Format("Echec : {0}", result.Errors.ToList()[0]);
                        return View(modelUtilisateur);
                    }
                }
                else
                {
                    TempData["_StatusMessage"] = string.Format("Un utilisateur ayant l'Email << {0} >> existe déjà", modelUtilisateur.Email);
                    return View(modelUtilisateur);
                }
                return RedirectToAction("Index");
            }
            return View(modelUtilisateur);
        }

        //
        //
        // GET: Utilisateur/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            //ApplicationDbContext db = new ApplicationDbContext();
            //on recupère les utilisateur
            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            UtilisateurModelVueEdit rolManager = new UtilisateurModelVueEdit
            {
                Utilisateur = await _userManager.FindByIdAsync(id),
                Id = id,
            };
            rolManager.UserName = rolManager.Utilisateur.NomPrenom;
            rolManager.Email = rolManager.Utilisateur.Email;
            rolManager.PhoneNumber = rolManager.Utilisateur.PhoneNumber;


            if (rolManager.Utilisateur == null)
            {
                return RedirectToAction("Index");
            }

            return View(rolManager);
        }

        // POST: Utilisateur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]// Afin de déjouer les attaques par sur-validation
        public async Task<IActionResult> Edit(UtilisateurModelVueEdit modelUtilisateur)
        {
            if (ModelState.IsValid)
            {
                //ApplicationDbContext db = new ApplicationDbContext();
                //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                bool trouver = _userManager.Users.Where(e => e.Email == modelUtilisateur.Email && e.Id != modelUtilisateur.Id).Count() > 0;

                if (!trouver)
                {
                    UserEntity Utilisateur = new UserEntity();
                    Utilisateur = await _userManager.FindByIdAsync(modelUtilisateur.Id);

                    Utilisateur.NomPrenom = modelUtilisateur.UserName;
                    Utilisateur.Email = modelUtilisateur.Email;
                    Utilisateur.PhoneNumber = modelUtilisateur.PhoneNumber;

                    IdentityResult result = await _userManager.UpdateAsync(Utilisateur);

                    if (result.Succeeded)
                    {
                        TempData["_StatusMessage"] = string.Format("{0} as été modifier avec succès", modelUtilisateur.UserName);
                    }
                    else
                    {
                        int errorCount = result.Errors.Count();
                        TempData["_StatusMessage"] = string.Format("Echec : {0}", result.Errors.ToList()[0]);
                        return View(modelUtilisateur);
                    }
                }
                else
                {
                    TempData["_StatusMessage"] = string.Format("Un utilisateur ayant l'Email << {0} >> existe déjà", modelUtilisateur.Email);
                    return View(modelUtilisateur);
                }
                return RedirectToAction("Index");
            }
            return View(modelUtilisateur);
        }

        //
        //
        // GET: Utilisateur/Details/5
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            //on recupère les roles
            var roles = await _userManager.GetRolesAsync(user);

            //on recupere les users de la bd
            UtilisateurModelVue rolManager = new UtilisateurModelVue
            {
                Utilisateur = user,
                Roles = roles
            };

            return View(rolManager);
        }
    }
}
