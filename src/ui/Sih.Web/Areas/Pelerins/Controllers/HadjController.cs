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
    public class HadjController : Controller
    {
        private readonly IHadjApplication _context;
        public HadjController(IHadjApplication context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lsthadj =await  _context.GetAll();
            return View(lsthadj);
        }

        //Get
        public async Task<IActionResult> AddOrUpDate(int id)
        {
            if (id == 0)
            {
                return View(new HadjEntity());
            }
            else
            {
                return View(await _context.GetById(id));
            }
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> AddOrUpDate([Bind("HadjEntityId,Edition,Datedebut,Datefin,Quota,Prix")] HadjEntity hadj)
        {
            if (ModelState.IsValid)
            {
                if (hadj.HadjEntityId == 0)
                {
                    await _context.Ajouter(hadj);
                }
                else
                {
                    await _context.Modifier(hadj);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(hadj);
            }
        }
        [HttpPost]
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
