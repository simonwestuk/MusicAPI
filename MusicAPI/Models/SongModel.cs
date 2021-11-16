using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPI.Models
{
    public class SongModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Artist { get; set; }

        //public Genre Genre { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
