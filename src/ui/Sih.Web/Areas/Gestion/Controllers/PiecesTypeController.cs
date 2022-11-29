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
    public class PiecesTypeController : Controller
    {
        private readonly IPieceTypeApplication _context;
        public PiecesTypeController(IPieceTypeApplication context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }



        // GET: Gestion/PiecesType/Create
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new PiecesTypeEntity());
            }
            else
            {
                return View(await _context.GetById(id));
            }

        }

        // POST: Gestion/PiecesType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("PiecesTypeEntityId,Libelle")] PiecesTypeEntity piecesTypeEntity)
        {
            if (ModelState.IsValid)
            {
                if (piecesTypeEntity.PiecesTypeEntityId == 0)
                {
                    await _context.Ajouter(piecesTypeEntity);
                }
                else
                {
                    await _context.Modifier(piecesTypeEntity);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(piecesTypeEntity);
        }

       
        // POST: Gestion/PiecesType/Delete/5
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
