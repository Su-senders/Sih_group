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
    public class PiecesJointeApplication : IPiecesJointeApplication
    {
        private readonly IPiecesJointesDomain _context;
        public PiecesJointeApplication(IPiecesJointesDomain context)
        {
            _context = context;
        }
        public async Task Ajouter(PieceJointesEntity entity)
        {
            await _context.Ajouter(entity);
        }

        public async Task<List<PieceJointesEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<PieceJointesEntity> GetById(int Id)
        {
           return await _context.GetById(Id);
        }

        public async Task Modifier(PieceJointesEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(PieceJointesEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
