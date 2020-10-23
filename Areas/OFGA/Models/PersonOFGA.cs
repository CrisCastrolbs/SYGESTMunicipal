using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models
{
    public class PersonOFGA
    {
        public PersonOFGA()
        {
            Complaint = new HashSet<Complaint>();
        }

        [Key]
        [Display(Name = "Cédula o Pasaporte")]
        [Required(ErrorMessage = "Se debe digitar la cédula o el pasaporte")]
        public string PersonOFGAId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe digitar el apellido")]
        [Display(Name = "Primer Apellido")]
        public string LastName1 { get; set; }

        [Required(ErrorMessage = "Debe digitar el apellido")]
        [Display(Name = "Segundo Apellido")]
        public string LastName2 { get; set; }


        [Required(ErrorMessage = "Debe digitar la dirección exacta")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Debe digitar la provincia ")]
        [Display(Name = "Provincia")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Debe digitar el Cantón ")]
        [Display(Name = "Cantón")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "Debe digitar el Distrito ")]
        [Display(Name = "Distrito")]
        public string District { get; set; }


        [Display(Name = "Número de Teléfono")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Debe digitar el número de celular")]
        [Display(Name = "Número de Celular")]
        public string CellphoneNumber { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        public virtual ICollection<Complaint> Complaint { get; set; }
    }
}
