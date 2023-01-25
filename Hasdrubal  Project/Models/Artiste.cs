using System;
using System.Collections.Generic;

namespace Hasdrubal__Project.Models
{
    public class Artiste
    {
        public int Id { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Nationalite { get; set; }
        public string Biographie { get; set; }
        public ICollection<Oeuvre> Oeuvres { get; set; }
    }
}
