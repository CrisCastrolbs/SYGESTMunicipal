using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class CIIU
    {
        public CIIU()
        {
            Establishment = new HashSet<Establishment>();
        }
        [Key]
        public int CIIUId { get; set; }
        [Required]
        [Display(Name = "Codigo")]
        public string Name { get; set; }
        public virtual ICollection<Establishment> Establishment { get; set; }
    }
}
