using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Medicament
    {
        public Medicament()
        {
            Constituers = new HashSet<Constituer>();
            Offrirs = new HashSet<Offrir>();
            Prescrires = new HashSet<Prescrire>();
            MedMedPerturbes = new HashSet<Medicament>();
            MedPerturbateurs = new HashSet<Medicament>();
            PreCodes = new HashSet<Presentation>();
        }

        public string MedDepotlegal { get; set; } = null!;
        public string? MedNomcommercial { get; set; }
        public string FamCode { get; set; } = null!;
        public string? MedComposition { get; set; }
        public string? MedEffets { get; set; }
        public string? MedContreindic { get; set; }
        public float? MedPrixechantillon { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;

        public virtual Famille FamCodeNavigation { get; set; } = null!;
        public virtual ICollection<Constituer> Constituers { get; set; }
        public virtual ICollection<Offrir> Offrirs { get; set; }
        public virtual ICollection<Prescrire> Prescrires { get; set; }

        public virtual ICollection<Medicament> MedMedPerturbes { get; set; }
        public virtual ICollection<Medicament> MedPerturbateurs { get; set; }
        public virtual ICollection<Presentation> PreCodes { get; set; }
    }
}
