using System;
using System.Collections.Generic;
using System.Text;

namespace Musica.Domain.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
    }
}
