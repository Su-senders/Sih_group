using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Localisation;
using Sih.Entities.Localisation;
using Sih.Persistence.Configurations;

namespace Sih.Web.Areas.Localisation.Controllers
{
    [Area("Localisation")]
    public class VilleController : Controller
    {
        private readonly IVilleApplication _context;

        public VilleController(IVilleApplication context)
        {
            _context = context;
        }

        // GET: Localisation/Ville
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        

        // GET: Localisation/Ville/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new VilleEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Localisation/Ville/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("VilleEntityId,NomVille,RegionEntityId")] VilleEntity villeEntity)
        {
            if (ModelState.IsValid)
            {
                if (villeEntity.VilleEntityId == 0)
                {
                    await _context.Ajouter(villeEntity);
                }
                else
                {
                    await _context.Modifier(villeEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RegionEntityId"] = new SelectList(_context.GetAll(), "RegionEntityId", "RegionEntityId", villeEntity.RegionEntityId);
            return View(villeEntity);
        }

        

        
        // POST: Localisation/Ville/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
