using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Famille
    {
        public Famille()
        {
            Medicaments = new HashSet<Medicament>();
        }

        public string FamCode { get; set; } = null!;
        public string? FamLibelle { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}
