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
    public class PieceJointesController : Controller
    {
        private readonly IPiecesJointeApplication _context;
        private readonly IPieceTypeApplication _contextp;
        private readonly IInscriptionApplication _contexti;
        public PieceJointesController(IPiecesJointeApplication context,
            IInscriptionApplication contexti, IPieceTypeApplication contextp)
        {
            _context = context;
            _contextp = contextp;
            _contexti = contexti;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _context.GetAll();
            return View(lst);
        }

       

       
        // GET: Gestion/PieceJointes/Create
        public IActionResult AddOrUpdate(int id)
        {
            ViewData["InscriptionEntityId"] = new SelectList(_contexti.GetAll().Result, "InscriptionEntityId", "InscriptionEntityId");
            ViewData["PiecesTypeEntityId"] = new SelectList(_contextp.GetAll().Result, "PiecesTypeEntityId", "PiecesTypeEntityId");
            if (id == 0)
            {
                return View(new PiecesTypeEntity());
            }
            else
            {
                return View(_context.GetById(id));
            }
        }

        // POST: Gestion/PieceJointes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PieceJointesEntityId,FileName,FileContentType,FileSize,FileNumerise,Qualite,InscriptionEntityId,PiecesTypeEntityId")] PieceJointesEntity pieceJointesEntity)
        {
            if (ModelState.IsValid)
            {
                if (pieceJointesEntity.PieceJointesEntityId == 0)
                {
                    await _context.Ajouter(pieceJointesEntity);
                }
                else
                {
                    await _context.Modifier(pieceJointesEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscriptionEntityId"] = new SelectList(_contexti.GetAll().Result, "InscriptionEntityId", "InscriptionEntityId", pieceJointesEntity.InscriptionEntityId);
            ViewData["PiecesTypeEntityId"] = new SelectList(_contextp.GetAll().Result, "PiecesTypeEntityId", "PiecesTypeEntityId", pieceJointesEntity.PiecesTypeEntityId);
            return View(pieceJointesEntity);
        }

       

        // POST: Gestion/PieceJointes/Delete/5
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
