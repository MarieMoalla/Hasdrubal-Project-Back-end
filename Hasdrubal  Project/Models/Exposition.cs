using System;
using System.Collections.Generic;

namespace Hasdrubal__Project.Models
{
    public class Exposition
    {
        public int Id { get; set; }
        public string Contraintes { get; set; }
        public string TitreExpo { get; set; }
        public string Lieu { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        //foreign key
        public ICollection<Pret> Prets { get; set; }
    }
}
