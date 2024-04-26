using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Dosage
    {
        public Dosage()
        {
            Prescrires = new HashSet<Prescrire>();
        }

        public string DosCode { get; set; } = null!;
        public string? DosQuantite { get; set; }
        public string? DosUnite { get; set; }

        public virtual ICollection<Prescrire> Prescrires { get; set; }
    }
}
