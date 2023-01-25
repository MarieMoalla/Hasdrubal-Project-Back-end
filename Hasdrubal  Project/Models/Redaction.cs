﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hasdrubal__Project.Models
{
    public class Redaction
    {
        [ForeignKey("Oeuvre")]
        public int Id { get; set; }
        public string NomRedacteur { get; set; }
        public DateTime DateRedaction { get; set; }
        public DateTime DateModification { get; set; }

        //foreign key
        [JsonIgnore]
        public virtual Oeuvre Oeuvre { get; set; }
        public int OeuvreId { get; set; }
    }
}
