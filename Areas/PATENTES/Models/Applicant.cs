using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class Applicant
    {
        public Applicant()
        {
            Establishment = new HashSet<Establishment>();
        }
        [Key]
        public int ApplicantId { get; set; }
        [Required]
        [Display(Name = "Solicitante")]
        public string Name { get; set; }
        public virtual ICollection<Establishment> Establishment { get; set; }
    }
}
