using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        Peinture,
        Sculpture,
        Arts_graphiques,
        Photographie,
        Vidéo,
        Textile,
        Installation,
        Autres,
    }
    public class Oeuvre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string NomArtiste { get; set; }
        public string PresnomArtiste { get; set; }
        public int DateCreation { get; set; }
        public string Materiaux { get; set; }
        public string Support { get; set; }
        public string Dimensions2D { get; set; }
        public string Dimensions3D { get; set; }
        public int Poid { get; set; }
        public int NbElements { get; set; }
        public int NumeroTitrage { get; set; }
        public Type TypeTitrage { get; set; }
        public string Description { get; set; }

        //foreign keys 
        public Artiste Artiste { get; set; }
        public int ArtisteId { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public ICollection<Pret> Prets { get; set; }

        public Acquisation Acquisation { get; set; }
        public Bibliographie Bibliographie { get; set; }
        public ConservationLocation ConservationLocation { get; set; }
        public Redaction Redaction { get; set; }
        public Restauration Restauration { get; set; }
        public Signature Signature { get; set; }
}
}
