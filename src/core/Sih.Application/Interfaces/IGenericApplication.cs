using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Interfaces
{
    public interface IGenericApplication<T> where T : class
    {
        Task Ajouter(T entity);
        Task Modifier(T entity);
        Task Supprimer(T entity);
        Task<T> GetById(int Id);
        Task<List<T>> GetAll();
    }
}
