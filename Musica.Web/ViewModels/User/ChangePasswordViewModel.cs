using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.Users
{
    public class ChangePasswordViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }
        public string UserName{ get; set; }


        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(100, ErrorMessage = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
