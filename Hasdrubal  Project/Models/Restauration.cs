using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    public class Restauration
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string Constat { get; set; }
        public string Cause { get; set; }
        public DateTime DateRestauration { get; set; }
        public string LieuRestauration { get; set; }
        public string NomRestauration { get; set; }
        public string TypeIntervention { get; set; }
        public string Materiaux { get; set; }
        //foreign key
        [JsonIgnore]
        public virtual Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }

    }
}
