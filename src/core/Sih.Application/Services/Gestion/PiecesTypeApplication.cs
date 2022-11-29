using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sih.Application.Interfaces.Gestion;
using Sih.Domain.Interfaces.Gestion;
using Sih.Entities.Gestion;

namespace Sih.Application.Services.Gestion
{
    public class PiecesTypeApplication : IPieceTypeApplication
    {
        private readonly IPiecesTypesDomain _context;
        public PiecesTypeApplication(IPiecesTypesDomain context)
        {
            _context = context;
        }
        public async  Task Ajouter(PiecesTypeEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<PiecesTypeEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<PiecesTypeEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async  Task Modifier(PiecesTypeEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(PiecesTypeEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
