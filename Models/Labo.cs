using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Labo
    {
        public Labo()
        {
            Visiteurs = new HashSet<Visiteur>();
        }

        public string LabCode { get; set; } = null!;
        public string? LabNom { get; set; }
        public string? LabChefvente { get; set; }

        public virtual ICollection<Visiteur> Visiteurs { get; set; }
    }
}
