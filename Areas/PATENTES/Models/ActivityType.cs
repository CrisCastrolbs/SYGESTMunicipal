using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Establishment = new HashSet<Establishment>();
        }
        [Key]
        public int ActivityTypeId { get; set; }
        [Required]
        [Display(Name = "Tipo de actividad")]
        public string Name { get; set; }
        public virtual ICollection<Establishment> Establishment { get; set; }
    }
}
