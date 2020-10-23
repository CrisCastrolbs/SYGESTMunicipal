using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class DatosPersonaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Debe digitar la cédula o el pasaporte")]
        [Display(Name = "Cédula o Pasaporte: ")]
        public string PersonaOFIMId { get; set; }
        [Required(ErrorMessage = "Debe digitar el nombre")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Debe digitar el primer apellido")]
        [Display(Name = "Primer Apellido:")]
        public string LatName1 { get; set; }
        [Display(Name = "Segundo Apellido:")]
        public string LatName2 { get; set; }

        [Required(ErrorMessage = "Debe digitar la dirección exacta")]
        [Display(Name = "Dirección Exacta:")]
        public string Address { get; set; }
        [Display(Name = "Provincia:")]
        public string Province { get; set; }
        [Display(Name = "Cantón:")]
        public string Canton { get; set; }
        [Display(Name = "Distrito:")]
        public string District { get; set; }

        [Required(ErrorMessage = "Debe digitar el # de teléfono ")]
        [Display(Name = "Teléfono Fijo:")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Teléfono Celular:")]
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Sexo:")]
        public string Sex { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime DateBirth { get; set; }
        [Display(Name = "Nommbre Cóyuge:")]
        public string CoupleName { get; set; }
        [Display(Name = "Cantidad de Hijos:")]
        public int ChildNumber { get; set; }
        [Display(Name = "Discapacidades :")]
        public string Disability { get; set; }
        [Display(Name = "Padecimientos:")]
        public string MedicalCondition { get; set; }

        public int EstadoCivilId { get; set; }
        public string EstadoCivil { get; set; }
        public int OcupacionId { get; set; }
        public string Ocupacion { get; set; }
        public int NacionalidadId { get; set; }
        public string Nacionalidad { get; set; }
        public int NivelAcademicoId { get; set; }
        public string NivelAcademico { get; set; }
        public int SeguroId { get; set; }
        public string Seguro { get; set; }
        public string msgError { get; set; }

        public static implicit operator List<object>(DatosPersonaViewModel v)
        {
            throw new NotImplementedException();
        }

    }
}
