using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class TypeIndividu
    {
        public TypeIndividu()
        {
            Prescrires = new HashSet<Prescrire>();
        }

        public string TinCode { get; set; } = null!;
        public string? TinLibelle { get; set; }

        public virtual ICollection<Prescrire> Prescrires { get; set; }
    }
}
