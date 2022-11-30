using Sih.Entities.Gestion;
using Sih.Entities.Pelerins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sih.Entities.Enums.MesEnums;

namespace Sih.Application.Interfaces.Gestion
{
    public interface IVoyageApplication:IGenericApplication<VoyageEntity>
    {
        Task<string> Remplir_vol(int id, int idv, int nbre, Direction sens);
    }
}
