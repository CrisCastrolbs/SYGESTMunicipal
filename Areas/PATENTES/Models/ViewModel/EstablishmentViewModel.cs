using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models.ViewModel
{
    public class EstablishmentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "CIIU Id")]
        public int CIIUId { get; set; }

        [Display(Name = "CIIU Id")]
        public string CIIUName { get; set; }


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


        [Display(Name = "Id solicitante")]
        public int ApplicantId { get; set; }

        [Display(Name = "Se incluye solicitante")]
        public string ApplicantName { get; set; }

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

        [Display(Name = "Nombre de establecimiento")]
        public string EstablishmentTypeName { get; set; }


        [Display(Name = "Tipo de Actividad")]
        public int ActivityTypeId { get; set; }


        [Display(Name = "Nombre de la actividad")]
        public string ActivityTypeName { get; set; }


        public int SelectedOption { get; set; }

        public string msgError { get; set; }

        public IEnumerable<SelectListItem> Lista { get; set; }
    }
}
