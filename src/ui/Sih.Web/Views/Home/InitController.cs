using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sih.Entities.Administration;
using Sih.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Views.Home
{
    [AllowAnonymous]
    public class InitController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly SihDbContext _context;

        public InitController(UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SihDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await SihContextSeed.SihInitializer(_userManager, _roleManager, _context);
            return View();
        }
    }
}
