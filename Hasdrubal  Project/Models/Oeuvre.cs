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
        [JsonIgnore]
        public Artiste Artiste { get; set; }
        public int ArtisteId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Image> Images { get; set; }
        [JsonIgnore]
        public ICollection<Pret> Prets { get; set; }

        [JsonIgnore]
        public Acquisation Acquisation { get; set; }
        public int AcquisationId { get; set; }

        [JsonIgnore]
        public Bibliographie Bibliographie { get; set; }
        public int BibliographieId { get; set; }

        [JsonIgnore]
        public ConservationLocation ConservationLocation { get; set; }
        public int ConservationLocationId { get; set; }

        [JsonIgnore]
        public Redaction Redaction { get; set; }
        public int RedactionId { get; set; }

        [JsonIgnore]
        public Restauration Restauration { get; set; }
        public int RestaurationId { get; set; }

        [JsonIgnore]
        public Signature Signature { get; set; }
        public int SignatureId { get; set; }

    }
}
