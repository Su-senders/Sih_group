using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Entities.Pelerins
{
    public class UsagerEntity
    {
        [Key]
        public int UsagerEntityId { get; set; }
        [Required, Display(Name ="First Name")]
        public string Fname { get; set; }
        [Required, Display(Name = "Midle Name")]
        public string Mname { get; set; }
        [Required, Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required, Display(Name = "Place of Birth")]
        public string POBirth { get; set; }
        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime DOBirth { get; set; }
        [Required, Display(Name = "PassPort Number")]
        public string PassportN { get; set; }
        [Required, Display(Name = "PassPort Delivrance Date"), DataType(DataType.Date)]
        public DateTime PassportDel { get; set; }
        [Required, Display(Name = "PassPort Expiration Date"), DataType(DataType.Date)]
        public DateTime PassportExp { get; set; }
        [Required, Display(Name = "Departure Town")]
        public string Townn { get; set; }
        [Required, Display(Name = "Nationality")]
        public string Nationality { get; set; }
        [Required, Display(Name = "N° Tél")]
        public string NumTel { get; set; }
        [Required, Display(Name = "Email")]
        public string Email { get; set; }
    }
}
