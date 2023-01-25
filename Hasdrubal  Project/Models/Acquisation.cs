using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Moyen
    {
        Achat,
        Don,
        Legs
    }
    public class Acquisation
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public int PropriétaireActuel { get; set; }
        public int DateAcq { get; set; }
        public int LieuAcq { get; set; }
        public int Prix { get; set; }
        public Moyen MoyenAcq { get; set; }
        //doc
        public string PreuveAchat { get; set; }
        //doc
        public string CertificatAuthentication { get; set; }

        //foreign key
        [JsonIgnore]
        public virtual Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }
    }
}
