using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    public class Signature
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string OeuvreLocalisation { get; set; }
        public string Description { get; set; }

        //foreign key
        [JsonIgnore]
        public virtual Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }
    }
}
