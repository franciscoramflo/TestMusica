using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.Classes
{
    public class SecurityContext
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int? WarehouseId { get; set; }
    }
}
