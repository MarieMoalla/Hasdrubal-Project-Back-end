using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Mode
    {
        PAccrochée,
        Posée_au_sol,
        Roulée,
        Rayonnage,
        Emballée_papier_bulle,
        Emballée_papier_kraft
    }
    public class ConservationLocation
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string Lieu { get; set; }
        public string PlaceDepot { get; set; }
        public Mode ModeStockage { get; set; }

        //foreign key
        public virtual Oeuvre Oeuvre { get; set; }
    }
}
