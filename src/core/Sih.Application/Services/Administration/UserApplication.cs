using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sih.Application.Interfaces.Administration;
using Sih.Domain.Interfaces.Administration;
using Sih.Entities.Administration;

namespace Sih.Application.Services.Administration
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _context;
        public UserApplication(IUserDomain context)
        {
            _context = context;
        }

        public async Task Ajouter(UserEntity entity)
        {
            await _context.Ajouter(entity);
        }

        //public async Task<bool> AjouterUser(string username, string email, string password, string tel)
        //{
        //    return await AjouterUser(username,email,password,tel);
        //}

        //public async Task<bool> ExisteUser(string email, string password)
        //{
        //    return await ExisteUser(email,password);
        //}

        public async Task<List<UserEntity>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<UserEntity> GetById(int Id)
        {
            return await _context.GetById(Id);
        }

        public async Task Modifier(UserEntity entity)
        {
            await _context.Modifier(entity);
        }

        public async Task Supprimer(UserEntity entity)
        {
            await _context.Supprimer(entity);
        }
    }
}
