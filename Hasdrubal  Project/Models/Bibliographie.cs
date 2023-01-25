using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    public class Bibliographie
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string Publications { get; set; }
        public string TitreOuvrage { get; set; }
        public string NomAuteur { get; set; }
        public DateTime DatePublication { get; set; }
        public int Page { get; set; }
        public string Editeur { get; set; }

        //foreign key
        [JsonIgnore]
        public virtual Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }
    }
}
