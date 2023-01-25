using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace Hasdrubal__Project.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Copyright { get; set; }
        public string DroitsPhotographiques { get; set; }
        public string Uri { get; set; }
        public string name { get; set; }


        //foreign keys 
        [JsonIgnore]
        public Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }
    }
}
