using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sih.Application.Interfaces.Localisation;
using Sih.Entities.Localisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Localisation.Controllers
{
    [Area("Localisation")]
    public class RegionController : Controller
    {
        private readonly IRegionApplication _context;
        public RegionController(IRegionApplication context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }



        // GET: Localisation/Region/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new RegionEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Localisation/Region/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("RegionEntityId,CodeReg,NomReg")] RegionEntity regionEntity)
        {
            if (ModelState.IsValid)
            {
                if (regionEntity.RegionEntityId == 0)
                {
                    await _context.Ajouter(regionEntity);
                }
                else
                {
                    await _context.Modifier(regionEntity);
                }
                return RedirectToAction(nameof(Index)); ;
            }
            return View(regionEntity);
        }




        // POST: Localisation/Region/Delete/5
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
