using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Persistence.Configurations;

namespace Sih.Web.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    public class AvionController : Controller
    {
        private readonly IAvionApplication _context;
        public AvionController(IAvionApplication context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        

        // GET: Gestion/Avion/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new AvionEntity());
            }
            else
            {
                return View( _context.GetById(id));
            }
        }

        // POST: Gestion/Avion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("AvionEntityId,Capacite,NumAvion")] AvionEntity avionEntity)
        {
            if (ModelState.IsValid)
            {
                if (avionEntity.AvionEntityId == 0)
                {
                    await _context.Ajouter(avionEntity);
                }
                else
                {
                    await _context.Modifier(avionEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(avionEntity);
        }

        
        // POST: Gestion/Avion/Delete/5
        [HttpPost]
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
