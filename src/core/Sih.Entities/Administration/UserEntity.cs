using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sih.Entities.Administration
{
    public class UserEntity : IdentityUser
    {
        [Display(Name = "Noms et prénoms")]
        public string NomPrenom { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
