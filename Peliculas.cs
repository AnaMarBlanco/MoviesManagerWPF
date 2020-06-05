using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoviesManagerWPF
{
    class Peliculas
    {
        [Key]
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
    }
}
