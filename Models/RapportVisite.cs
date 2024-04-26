using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class RapportVisite
    {
        public RapportVisite()
        {
            Offrirs = new HashSet<Offrir>();
        }

        public string VisMatricule { get; set; } = null!;
        public int RapNum { get; set; }
        public short PraNum { get; set; }
        public DateTime? RapDate { get; set; }
        public string? RapBilan { get; set; }
        public string? RapMotif { get; set; }

        public virtual Praticien PraNumNavigation { get; set; } = null!;
        public virtual Visiteur VisMatriculeNavigation { get; set; } = null!;
        public virtual ICollection<Offrir> Offrirs { get; set; }
    }
}
