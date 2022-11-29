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
    public class AgrementController : Controller
    {
        private readonly IAgreementApplication _context;
        public AgrementController(IAgreementApplication context)
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
                return View(new AgreementEntity());
            }
            else
            {
                return View(await _context.GetById(id));
            }

        }
        //Post
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([Bind("SociteEntityId,Rsoc,BP,Tel,Hqter,sagerEntityId")] AgreementEntity agreementEntity)
        {
            if (agreementEntity.AgreementEntityId == 0)
            {
                await _context.Ajouter(agreementEntity);
            }
            else
            {
                await _context.Modifier(agreementEntity);
            }
            return RedirectToAction(nameof(Index));
        }
        //Delete
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

