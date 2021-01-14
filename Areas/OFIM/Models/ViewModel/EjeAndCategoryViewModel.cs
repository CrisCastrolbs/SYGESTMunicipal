using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.OFIM.Models.ViewModel
{
    public class EjeAndCategoryViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public Eje Eje { get; set; }
        public List<string> EjeList { get; set; }
        public string StatusMessage { get; set; }
    }
}
