using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string NomPrenom { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
