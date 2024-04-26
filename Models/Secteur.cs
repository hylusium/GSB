using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Secteur
    {
        public Secteur()
        {
            Regions = new HashSet<Region>();
            Visiteurs = new HashSet<Visiteur>();
        }

        public string SecCode { get; set; } = null!;
        public string? SecLibelle { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Visiteur> Visiteurs { get; set; }
    }
}
