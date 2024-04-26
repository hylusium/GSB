using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Visiteur
    {
        public Visiteur()
        {
            RapportVisites = new HashSet<RapportVisite>();
            Realisers = new HashSet<Realiser>();
            Travaillers = new HashSet<Travailler>();
        }

        public string VisMatricule { get; set; } = null!;
        public string? VisNom { get; set; }
        public string? VisPrenom { get; set; }
        public string? VisAdresse { get; set; }
        public string? VisCp { get; set; }
        public string? VisVille { get; set; }
        public DateTime? VisDateembauche { get; set; }
        public string? SecCode { get; set; }
        public string LabCode { get; set; } = null!;

        public virtual Labo LabCodeNavigation { get; set; } = null!;
        public virtual Secteur? SecCodeNavigation { get; set; }
        public virtual ICollection<RapportVisite> RapportVisites { get; set; }
        public virtual ICollection<Realiser> Realisers { get; set; }
        public virtual ICollection<Travailler> Travaillers { get; set; }
    }
}
