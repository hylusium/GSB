using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Presentation
    {
        public Presentation()
        {
            MedDepotlegals = new HashSet<Medicament>();
        }

        public string PreCode { get; set; } = null!;
        public string? PreLibelle { get; set; }

        public virtual ICollection<Medicament> MedDepotlegals { get; set; }
    }
}
