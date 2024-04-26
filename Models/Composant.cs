using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Composant
    {
        public Composant()
        {
            Constituers = new HashSet<Constituer>();
        }

        public string CmpCode { get; set; } = null!;
        public string? CmpLibelle { get; set; }

        public virtual ICollection<Constituer> Constituers { get; set; }
    }
}
