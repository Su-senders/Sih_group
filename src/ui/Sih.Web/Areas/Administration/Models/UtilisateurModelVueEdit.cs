using Microsoft.AspNetCore.Identity;
using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Models
{
    public class UtilisateurModelVueEdit
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ")]
        [Display(Name = "Nom et prénom")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ")]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ")]
        [Phone]
        [Display(Name = "N° Téléphone")]
        public string PhoneNumber { get; set; }

        public UserEntity Utilisateur { get; set; }
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
