using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models
{
    public partial class PersonaOFIM
    {
        [Key]
        [Required(ErrorMessage = "Debe digitar la cédula o el pasaporte")]
        [Display(Name = "Cédula o Pasaporte")]
        public string PersonaOFIMId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Debe digitar el nombre")]
        public string PersonName { get; set; }

        [DisplayName("Primer Apellido")]
        [Required(ErrorMessage = "Debe digitar el primer apellido")]
        public string LatName1 { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required(ErrorMessage = "Debe digitar el segundo apellido")]
        public string LatName2 { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Debe digitar la dirección exacta")]
        public string Address { get; set; }

        [DisplayName("Provincia")]
        [Required(ErrorMessage = "Debe digitar la provincia")]
        public string Province { get; set; }

        [DisplayName("Cantón")]
        public string Canton { get; set; }

        [DisplayName("Distrito")]
        [Required(ErrorMessage = "Debe digitar el Distrito")]
        public string District { get; set; }

        [DisplayName("Teléfono Fijo")]
        public string TelephoneNumber { get; set; }

        [DisplayName("Teléfono Móvil")]
        [Required(ErrorMessage = "Debe digitar el # de teléfono ")]
        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }

        [DisplayName("Sexo")]
        public string Sex { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Nombre Cónyuge")]
        public string CoupleName { get; set; }

        [DisplayName("Cantidad Hijos")]
        public int ChildNumber { get; set; }

        [DisplayName("Discapacidades")]
        public string Disability { get; set; }

        [DisplayName("Padecimientos")]
        public string MedicalCondition { get; set; }

        public int EstadoCivilId{ get; set; }
        [ForeignKey("EstadoCivilId")]
        public virtual EstadoCivil EstadoCivil { get; set; }

        public int OcupacionId { get; set; }
        [ForeignKey("OcupacionId")]
        public virtual Ocupacion Ocupacion { get; set; }

        public int NacionalidadId { get; set; }
        [ForeignKey("NacionalidadId")]
        public virtual Nacionalidad Nacionalidad { get; set; }

        public int NivelAcademicoId { get; set; }
        [ForeignKey("NivelAcademicoId")]
        public virtual NivelAcademico NivelAcademico { get; set; }
        public int SeguroId { get; set; }
        [ForeignKey("SeguroId")]
        public virtual Seguro Seguro { get; set; }
    }
}
