using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musica.Data.Entities
{
    public class Song
    {
        #region Properties

        [Key]
        public int SongId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }

        #endregion
    }
}
