using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Interfaces.Administration
{
    public interface IUserApplication: IGenericApplication<UserEntity>
    {
        //Task<bool> AjouterUser(string username, string email, string password, string tel);
        //Task<bool> ExisteUser(string email, string password);
    }
}
