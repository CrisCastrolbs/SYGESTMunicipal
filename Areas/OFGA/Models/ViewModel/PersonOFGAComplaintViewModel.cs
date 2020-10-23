using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFGA.Models.ViewModel
{
    public class PersonOFGAComplaintViewModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }



        [Display(Name = "Nombre Persona")]
        public string PersonOFGAId { get; set; }
        public string PersonOFGA { get; set; }
        public int SelectedOption { get; set; }

        public string msgError { get; set; }

        public IEnumerable<SelectListItem> Lista { get; set; }
    }
}
