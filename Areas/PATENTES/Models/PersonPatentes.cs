using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class PersonPatentes
    {
        [Key]
        [Display(Name = "Cédula o Pasaporte")]
        [Required(ErrorMessage = "Se debe digitar la cédula o el pasaporte")]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "Se debe digitar el nombre")]
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
        [Display(Name = "Provinvincia")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Debe digitar el Cantón ")]
        [Display(Name = "Cantón")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "Debe digitar el Distrito ")]
        [Display(Name = "Distrito")]
        public string District { get; set; }

        [Required(ErrorMessage = "Debe digitar el Barrio ")]
        [Display(Name = "Barrio")]
        public string Neighborhood { get; set; }

        [Display(Name = "Número de Teléfono")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Debe digitar el número de celular")]
        [Display(Name = "Número de Celular")]
        public string CellphoneNumber { get; set; }

        [Display(Name = "Número de Fax")]
        public string Fax { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        ////////////////////////////////////////


        [Display(Name = "Nombre")]
        public string NameF { get; set; }


        [Display(Name = "Primer Apellido")]
        public string LastName1F { get; set; }


        [Display(Name = "Segundo Apellido")]
        public string LastName2F { get; set; }

        [Display(Name = "Cédula o Pasaporte")]
        public string FisicID { get; set; }

        ///////////////////////////
        [Display(Name = "Nombre")]
        public string NameJ { get; set; }

        [Display(Name = "Nombre")]
        public string NameJS { get; set; }

        [Display(Name = "Cédula juridica")]
        public string JuridicId { get; set; }
        // [Display(Name = "Certificado de persona Juridica")]
        //public bool CPJ { get; set; }
    }
}
