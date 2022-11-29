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
    public class DepartureTownController : Controller
    {
        private readonly IDepartureTownApplication _context;
        private readonly IVilleApplication _contextv;

        public DepartureTownController(IDepartureTownApplication context,
            IVilleApplication contextv)
        {
            _context = context;
            _contextv = contextv;
        }

        // GET: Localisation/DepartureTown
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        

        // GET: Localisation/DepartureTown/Create
        public IActionResult AddOrUpdate(int id)
        {
            ViewData["VilleEntityId"] = new SelectList(_contextv.GetAll().Result, "VilleEntityId", "VilleEntityId");
            if (id == 0)
            {
                return View(new RegionEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Localisation/DepartureTown/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartureTownEntityId,UsagerEntityId,HadjEntityId,VilleEntityId")] DepartureTownEntity departureTownEntity)
        {
            if (ModelState.IsValid)
            {
                if (departureTownEntity.DepartureTownEntityId == 0)
                {
                    await _context.Ajouter(departureTownEntity);
                }
                else
                {
                    await _context.Modifier(departureTownEntity);
                }
                return RedirectToAction(nameof(Index)); ;
            }
            ViewData["VilleEntityId"] = new SelectList(_contextv.GetAll().Result, "VilleEntityId", "VilleEntityId", departureTownEntity.VilleEntityId);
            return View(departureTownEntity);
        }

       

        // POST: Localisation/DepartureTown/Delete/5
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
