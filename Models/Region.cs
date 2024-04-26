using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Region
    {
        public Region()
        {
            Travaillers = new HashSet<Travailler>();
        }

        public string RegCode { get; set; } = null!;
        public string SecCode { get; set; } = null!;
        public string? RegNom { get; set; }

        public virtual Secteur SecCodeNavigation { get; set; } = null!;
        public virtual ICollection<Travailler> Travaillers { get; set; }
    }
}
