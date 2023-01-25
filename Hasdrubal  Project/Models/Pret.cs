using System;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Oeuvre Oeuvre { get; set; }

        public int ExpositionId { get; set; }
        [JsonIgnore]
        public Exposition Exposition { get; set; }
        
    }
}
