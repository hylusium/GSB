using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class ActiviteCompl
    {
        public ActiviteCompl()
        {
            Inviters = new HashSet<Inviter>();
            Realisers = new HashSet<Realiser>();
        }

        public int AcNum { get; set; }
        public DateTime? AcDate { get; set; }
        public string? AcLieu { get; set; }
        public string? AcTheme { get; set; }
        public string? AcMotif { get; set; }

        public virtual ICollection<Inviter> Inviters { get; set; }
        public virtual ICollection<Realiser> Realisers { get; set; }
    }
}
