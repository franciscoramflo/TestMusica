using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.Users
{
    public class UserEditViewModel
    {
        [Display(Name = "Id")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Teléfono")]
        public string PhoneNumber{ get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Empleado")]
        public int? StaffId { get; set; }

        
        [StringLength(255, MinimumLength = 1, ErrorMessage = "StringLength")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool IsAdministrator { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdministrative { get; set; }
        public bool IsDeliveryChief { get; set; }
        public bool IsDeliveryAux { get; set; }
        public bool IsSales { get; set; }
        public bool IsOperator { get; set; }
        public bool IsWholeSaler { get; set; }
        public bool IsSaleChief { get; set; }
    }
}
