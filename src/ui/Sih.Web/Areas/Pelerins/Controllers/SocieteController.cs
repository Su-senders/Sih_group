using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Pelerins;
using Sih.Entities.Pelerins;
using Sih.Persistence.Configurations;

namespace Sih.Web.Areas.Pelerins.Controllers
{
    [Area("Pelerins")]
    public class SocieteController : Controller
    {
        private readonly ISocieteApplication _context;
        public SocieteController(ISocieteApplication context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        //Get
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new UsagerEntity());
            }
            else
            {
                return View(await _context.GetById(id));
            }

        }
        //Post

        public async Task<IActionResult> AddOrUpdate([Bind("SociteEntityId,Rsoc,BP,Tel,Hqter,sagerEntityId")] SocieteEntity societeEntity)
        {
            if (societeEntity.SociteEntityId == 0)
            {
                await _context.Ajouter(societeEntity);
            }
            else
            {
                await _context.Modifier(societeEntity);
            }
            return RedirectToAction(nameof(Index));
        }
        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var eltSupr = await _context.GetById(id);
            if (eltSupr != null)
            {
                await _context.Supprimer(eltSupr);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
