using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Areas.Admin.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string IdPassport { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Canton { get; set; }
        public string Province { get; set; }

}

}
