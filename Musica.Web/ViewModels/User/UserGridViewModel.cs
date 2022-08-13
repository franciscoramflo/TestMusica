using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.Users
{
    public class UserGridViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public int? StaffId { get; set; }
        public string Profile { get; set; }
    }
}
