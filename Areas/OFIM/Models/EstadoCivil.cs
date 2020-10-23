using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            PersonaOFIM = new HashSet<PersonaOFIM>();
        }
        [Key] 
        [Required]
        public int EstadoCivilId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
    }
}
