using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models
{
    public partial class Establishment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe digitar el nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "CIIU")]
        public int CIIUId { get; set; }
        [ForeignKey("CIIUId")]
        public virtual CIIU CIIU { get; set; }

        [Display(Name = "Descripcion de actividad")]
        [Required(ErrorMessage = "Debe digitar la descripción de la actividad")]
        public string Description { get; set; }

        [Display(Name = "Otras Actividades (Si poseé)")]
        public string OtherActivities { get; set; }

        [Display(Name = "Nº de finca")]
        [Required(ErrorMessage = "Debe digitar el numero de finca")]
        public string NFarm { get; set; }

        [Display(Name = "Nº de plano")]
        [Required(ErrorMessage = "Debe digitar el numero de plano")]
        public string DesignNum { get; set; }


        [Display(Name = "Horario De trabajo")]
        [Required(ErrorMessage = "Debe digitar el horario de trabajo")]
        public string WorkingHours { get; set; }

        [Display(Name = "Cantidad de hombres trabajando")]
        [Required(ErrorMessage = "Debe digitar la cantidad de hombres que trabajan en este establecimineto")]
        public string WMen { get; set; }

        [Display(Name = "Cantidad de mujeres trabajando")]
        [Required(ErrorMessage = "Debe digitar la cantidad de hombres que trabajan en este establecimineto")]
        public string WWomen { get; set; }


        [Display(Name = "Se incluye solicitante")]
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }

        [Display(Name = "Direccion de pagina Web")]
        public string WebPage { get; set; }

        [Display(Name = "Cantidad de trabajadores calificados")]
        [Required(ErrorMessage = "Debe digitar la cantidad de trabajadores calificados")]
        public string SkilledWorkers { get; set; }

        [Display(Name = "Cantidad de no trabajadores calificados")]
        [Required(ErrorMessage = "Debe digitar la cantidad de trabajadores no calificados")]
        public string UnskilledWorkers { get; set; }

        [Display(Name = "Tipo De Establecimiento")]
        public int EstablishmentTypeId { get; set; }
        [ForeignKey("EstablishmentTypeId")]
        public virtual EstablishmentType EstablishmentType { get; set; }

        [Display(Name = "Tipo de Actividad")]
        public int ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}
