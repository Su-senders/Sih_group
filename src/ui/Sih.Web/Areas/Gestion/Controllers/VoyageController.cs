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
    public class VoyageController : Controller
    {
        private readonly IVoyageApplication _context;

        public VoyageController(IVoyageApplication context)
        {
            _context = context;
        }

        // GET: Gestion/Voyage
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }



        // GET: Gestion/Voyage/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new VoyageEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Gestion/Voyage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("VoyageEntityId,VolEntityId,UsagerEntityId,Direction,Datedepart")] VoyageEntity voyageEntity)
        {
            if (ModelState.IsValid)
            {
                if (voyageEntity.VolEntityId == 0)
                {
                    await _context.Ajouter(voyageEntity);
                }
                else
                {
                    await _context.Modifier(voyageEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voyageEntity);
        }

        

        // POST: Gestion/Voyage/Delete/5
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
