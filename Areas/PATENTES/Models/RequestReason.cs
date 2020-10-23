using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class RequestReason
    {
        [Key]
        public int RequestReasonId { get; set; }
        [Required]
        [Display(Name = "Razon de solicitud")]
        public string Name { get; set; }
        //public virtual ICollection<Establishment>Establishment { get; set; }
    }
}
