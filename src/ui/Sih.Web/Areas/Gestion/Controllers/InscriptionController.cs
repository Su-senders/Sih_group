using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sih.Application.Interfaces.Gestion;
using Sih.Entities.Gestion;
using Sih.Entities.Enums;
using Sih.Persistence.Configurations;
using static Sih.Entities.Enums.MesEnums;

namespace Sih.Web.Areas.Gestion.Controllers
{
    [Area("Gestion")]
    public class InscriptionController : Controller
    {
        private readonly IInscriptionApplication _context;

        public InscriptionController(IInscriptionApplication context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

        //Get
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id == 0)
            {
                return View(new InscriptionEntity());

            }
            else
            {
                return View(await _context.GetById(id));
            }
            //prevoir les viewbags
        }
        //Post

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([Bind("InscriptionEntityId,UsagerEntityId,HadjEntityId,Standing,Paiement,DateIns")] InscriptionEntity inscription)
        {
            if (inscription.InscriptionEntityId == 0)
            {
                inscription.Etat = Etat_Traitement.Enregister;
                 await _context.Ajouter(inscription);
            }
            else
            {
                await _context.Modifier(inscription);
            }
            return RedirectToAction(nameof(Index));
        }
        //Delete
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
