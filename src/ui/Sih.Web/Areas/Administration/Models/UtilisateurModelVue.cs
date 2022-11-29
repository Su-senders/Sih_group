using Microsoft.AspNetCore.Identity;
using Sih.Entities.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Areas.Administration.Models
{
    public class UtilisateurModelVue
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

        [Required(ErrorMessage = "Veuillez renseigner ce champ")]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public UserEntity Utilisateur { get; set; }
        public IdentityRole Role { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
