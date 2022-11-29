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
    public class EncadreurController : Controller
    {
        private readonly IEncadreurApplication _context;

        public EncadreurController(IEncadreurApplication context)
        {
            _context = context;
        }

        // GET: Pelerins/Encadreur
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        
        // GET: Pelerins/Encadreur/Create
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new EncadreurEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Pelerins/Encadreur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("EncadreurEntityId,Fname,Mname,Lname,POBirth,DOBirth,PassportN,PassportDel,PassportExp,Dtownn,Nationality")] EncadreurEntity encadreurEntity)
        {
            if (ModelState.IsValid)
            {
                if (encadreurEntity.EncadreurEntityId == 0)
                {
                    await _context.Ajouter(encadreurEntity);
                }
                else
                {
                    await _context.Modifier(encadreurEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(encadreurEntity);
        }

        

        

        // GET: Pelerins/Encadreur/Delete/5
        

        // POST: Pelerins/Encadreur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eltSupr = await _context.GetById(id);
            if(eltSupr!=null)
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
