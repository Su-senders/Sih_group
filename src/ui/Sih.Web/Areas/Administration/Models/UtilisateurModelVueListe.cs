using Sih.Entities.Administration;
using Sih.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Models
{
    public class UtilisateurModelVueListe
    {
        public IEnumerable<UserEntity> Utilisateurs { get; set; }
        public Pager PageInfo { get; set; }
    }
}
