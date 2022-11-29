using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sih.Web.Areas.Localisation.Models
{
    public class LocalisationViewModel
    {
        public int Region { get; set; }
        public int Departement { get; set; }
        public int Arrondissement { get; set; }
        [Display(Name = "Ville / ville la plus proche")]
        public int Ville { get; set; }
        public int Localite { get; set; }
        public IEnumerable<SelectListItem> Localites { get; set; }
        public IEnumerable<SelectListItem> Communes { get; set; }
        public IEnumerable<SelectListItem> Villes { get; set; }
        public IEnumerable<SelectListItem> Departements { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
    }
}
