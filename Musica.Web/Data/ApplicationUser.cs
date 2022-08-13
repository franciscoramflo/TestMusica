using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
