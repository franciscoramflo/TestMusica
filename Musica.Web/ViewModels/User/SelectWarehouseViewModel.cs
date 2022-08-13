using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.User
{
    public class SelectWarehouseViewModel
    {
        [Required(ErrorMessage = "FieldRequired")]        
        [Display(Name = "Almacén")]
        public int? WarehouseId { get; set; }
    }
}
