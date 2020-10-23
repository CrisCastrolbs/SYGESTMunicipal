﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.PATENTES.Models.ViewModel
{
    public class SelectViewModel
    {
        public int SelectedOption { get; set; }
        public IEnumerable<SelectListItem> Lista { get; set; }
    }
}
