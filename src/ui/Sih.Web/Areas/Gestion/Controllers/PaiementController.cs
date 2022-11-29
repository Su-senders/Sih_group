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
    public class PaiementController : Controller
    {
        private readonly IPaiementApplication _context;
        private readonly IInscriptionApplication _contexti;
        public PaiementController(IPaiementApplication context, IInscriptionApplication contexti)
        {
            _context = context;
            _contexti = contexti;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        //Get
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["InscriptionEntityId"] = new SelectList(_contexti.GetAll().Result, "InscriptionEntityId", "InscriptionEntityId");
            if (id == 0)
            {
                return View(new PaiementEntity());
            }
            else
            {
                return View(await _context.GetById(id));
            }

        }
       

        // POST: Gestion/Paiement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("PaiementEntityId,Dateversement,Montant,InscriptionEntityId")] PaiementEntity paiementEntity)
        {
            if (ModelState.IsValid)
            {
                if (paiementEntity.PaiementEntityId == 0)
                {
                    
                    await _context.Ajouter(paiementEntity);
                }
                else
                {
                    await _context.Modifier(paiementEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscriptionEntityId"] = new SelectList(_contexti.GetAll().Result, "InscriptionEntityId", "InscriptionEntityId", paiementEntity.InscriptionEntityId);
            return View(paiementEntity);
        }

        
        // POST: Gestion/Paiement/Delete/5
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
