using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.Users
{
    public class UserCreateViewModel
    {
        [Display(Name = "Id")]
        public string UserId { get; set; }
        
        [StringLength(255, MinimumLength = 1, ErrorMessage = "StringLength")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        
        [StringLength(255, MinimumLength = 1,ErrorMessage = "StringLength")]
        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "Phone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "StringLength")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [StringLength(255, MinimumLength = 1, ErrorMessage = "StringLength")]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage ="Este campo debe ser un correo electrónico válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "StringLength")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Empleado")]
        public int? StaffId { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Administrador")]
        public Boolean IsAdministrator { get; set; }
        [Display(Name = "Gerencial")]
        public Boolean IsManager { get; set; }
        [Display(Name = "Administrativo")]
        public Boolean IsAdministrative { get; set; }
        [Display(Name = "Jefe de Reparto")]
        public Boolean IsDeliveryChief { get; set; }
        [Display(Name = "Operador")]
        public Boolean IsOperator { get; set; }

        [Display(Name = "Auxiliar de Reparto")]
        public bool IsDeliveryAux { get; set; }

        [Display(Name = "Ventas")]
        public bool IsSales { get; set; }


        [Display(Name = "Almacenista")]
        public bool IsWholeSaler { get; set; }

        [Display(Name = "Jefe de Ventas")]
        public bool IsSaleChief { get; set; }

    }
}
