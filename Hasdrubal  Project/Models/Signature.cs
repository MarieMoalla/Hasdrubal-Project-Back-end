using System.ComponentModel.DataAnnotations.Schema;

namespace Hasdrubal__Project.Models
{
    public class Signature
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string OeuvreLocalisation { get; set; }
        public string Description { get; set; }

        //foreign key
        public virtual Oeuvre Oeuvre { get; set; }
    }
}
