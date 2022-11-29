using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Application.Interfaces.Gestion
{
    public interface IVolApplication:IGenericApplication<VolEntity>
    {
        Task<List<UsagerEntity>> Remplir_vol(int id);
    }
}
