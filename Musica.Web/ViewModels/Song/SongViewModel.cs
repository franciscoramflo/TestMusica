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
        [Display(Name = "Canción")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Artista")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Año")]
        public int Year { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [Display(Name = "Genero")]
        public string Gender { get; set; }

        public bool Active { get; set; }
    }
}
