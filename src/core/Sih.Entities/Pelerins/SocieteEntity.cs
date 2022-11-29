using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sih.Entities.Pelerins
{
    public class SocieteEntity
    {
        [Key]
        public int SociteEntityId { get; set; }
        [Required, Display(Name = "Company Name")]
        public string Rsoc { get; set; }
        [Required, Display(Name = "P.O Pox")]
        public string BP { get; set; }
        [Required, Display(Name = "Telephone")]
        public string Tel { get; set; }
        [Required, Display(Name = "Headquater")]
        public string Hqter { get; set; }
        public int EncadreurEntityId { get; set; }
        public virtual EncadreurEntity CEO { get; set; }
    }
}
