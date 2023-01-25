using System;

namespace Hasdrubal__Project.Models
{
    public class Pret
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string NomExpo { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateRetour { get; set; }

        public int OeuvreId { get; set; }
        public Oeuvre Oeuvre { get; set; }

        public int ExpositionId { get; set; }
        public Exposition Exposition { get; set; }
    }
}
