using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hasdrubal__Project.Models
{
    public class Artiste
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Nationalite { get; set; }
        public string Biographie { get; set; }
        [JsonIgnore]
        public ICollection<Oeuvre> Oeuvres { get; set; }
    }
}
