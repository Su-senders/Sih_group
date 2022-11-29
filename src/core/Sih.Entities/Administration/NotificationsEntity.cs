using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Entities.Administration
{
    public class NotificationsEntity
    {
        public int NotificationsEntityId { get; set; }
        public string Titre { get; set; }
        public string Information { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [Display(Name = "Utilisateur")]
        public string UserEmail { get; set; }
    }
}
