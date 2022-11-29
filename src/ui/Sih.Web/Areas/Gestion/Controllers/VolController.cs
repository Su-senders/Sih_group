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
    public class VolController : Controller
    {
        private readonly IVolApplication _context;

        public VolController(IVolApplication context)
        {
            _context = context;
        }

        // GET: Gestion/Vol
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }



        // GET: Gestion/Vol/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new VolEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Gestion/Vol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("VolEntityId,Numvol,VilleId")] VolEntity volEntity)
        {
            if (ModelState.IsValid)
            {

                if (volEntity.VolEntityId == 0)
                {
                    await _context.Ajouter(volEntity);
                }
                else
                {
                    await _context.Modifier(volEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(volEntity);
        }



        // POST: Gestion/Vol/Delete/5
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
