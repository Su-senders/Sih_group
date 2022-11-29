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
    public class UsagerController : Controller
    {
        private readonly IUsagerApplication _context;

        public UsagerController(IUsagerApplication context)
        {
            _context = context;
        }

        // GET: Pelerins/Usager
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll(); //il faut filtrer uniquement les usagers nouvellemment inscrits.
            return View(lst);
           // return View(await _context.Usagers.ToListAsync());
        }

        
        // GET: Pelerins/Usager/Create
        public  IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View( new UsagerEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Pelerins/Usager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate([Bind("UsagerEntityId,Fname,Mname,Lname,POBirth,DOBirth,PassportN,PassportDel,PassportExp,Townn,Nationality")] UsagerEntity usagerEntity)
        {
            if (ModelState.IsValid)
            {
                if (usagerEntity.UsagerEntityId == 0)
                {
                    await _context.Ajouter(usagerEntity);
                }
                else
                {
                    await _context.Modifier(usagerEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usagerEntity);
        }

       

        // GET: Pelerins/Usager/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usagerEntity = await _context.Usagers
        //        .FirstOrDefaultAsync(m => m.UsagerEntityId == id);
        //    if (usagerEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usagerEntity);
        //}

        // POST: Pelerins/Usager/Delete/5
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
