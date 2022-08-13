using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.ViewModels.Song
{
    public class SongViewModel
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Título")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Grupo")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Año")]
        public int Year { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Género")]
        public string Gender { get; set; }

        public bool Active { get; set; }
    }
}
