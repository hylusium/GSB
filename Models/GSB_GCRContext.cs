using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSB_GCR.Models
{
    public partial class GSB_GCRContext : DbContext
    {
        public GSB_GCRContext()
        {
        }

        public GSB_GCRContext(DbContextOptions<GSB_GCRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiviteCompl> ActiviteCompls { get; set; } = null!;
        public virtual DbSet<Composant> Composants { get; set; } = null!;
        public virtual DbSet<Constituer> Constituers { get; set; } = null!;
        public virtual DbSet<Dosage> Dosages { get; set; } = null!;
        public virtual DbSet<Famille> Familles { get; set; } = null!;
        public virtual DbSet<Inviter> Inviters { get; set; } = null!;
        public virtual DbSet<Labo> Labos { get; set; } = null!;
        public virtual DbSet<Medicament> Medicaments { get; set; } = null!;
        public virtual DbSet<Offrir> Offrirs { get; set; } = null!;
        public virtual DbSet<Posseder> Posseders { get; set; } = null!;
        public virtual DbSet<Praticien> Praticiens { get; set; } = null!;
        public virtual DbSet<Prescrire> Prescrires { get; set; } = null!;
        public virtual DbSet<Presentation> Presentations { get; set; } = null!;
        public virtual DbSet<RapportVisite> RapportVisites { get; set; } = null!;
        public virtual DbSet<Realiser> Realisers { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Secteur> Secteurs { get; set; } = null!;
        public virtual DbSet<Specialite> Specialites { get; set; } = null!;
        public virtual DbSet<SwitchboardItem> SwitchboardItems { get; set; } = null!;
        public virtual DbSet<Travailler> Travaillers { get; set; } = null!;
        public virtual DbSet<TypeIndividu> TypeIndividus { get; set; } = null!;
        public virtual DbSet<TypePraticien> TypePraticiens { get; set; } = null!;
        public virtual DbSet<Visiteur> Visiteurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=HUGO;Initial Catalog=GSB_GCR;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiviteCompl>(entity =>
            {
                entity.HasKey(e => e.AcNum)
                    .HasName("ACTIVITE_COMPL$ACTIVITE_COMPL_PK");

                entity.ToTable("ACTIVITE_COMPL");

                entity.Property(e => e.AcNum).HasColumnName("AC_NUM");

                entity.Property(e => e.AcDate)
                    .HasPrecision(0)
                    .HasColumnName("AC_DATE");

                entity.Property(e => e.AcLieu)
                    .HasMaxLength(25)
                    .HasColumnName("AC_LIEU");

                entity.Property(e => e.AcMotif)
                    .HasMaxLength(50)
                    .HasColumnName("AC_MOTIF");

                entity.Property(e => e.AcTheme)
                    .HasMaxLength(10)
                    .HasColumnName("AC_THEME");
            });

            modelBuilder.Entity<Composant>(entity =>
            {
                entity.HasKey(e => e.CmpCode)
                    .HasName("COMPOSANT$COMPOSANT_PK");

                entity.ToTable("COMPOSANT");

                entity.Property(e => e.CmpCode)
                    .HasMaxLength(4)
                    .HasColumnName("CMP_CODE");

                entity.Property(e => e.CmpLibelle)
                    .HasMaxLength(25)
                    .HasColumnName("CMP_LIBELLE");
            });

            modelBuilder.Entity<Constituer>(entity =>
            {
                entity.HasKey(e => new { e.MedDepotlegal, e.CmpCode })
                    .HasName("CONSTITUER$CONSTITUER_PK");

                entity.ToTable("CONSTITUER");

                entity.HasIndex(e => e.MedDepotlegal, "CONSTITUER$LIEN_181_FK");

                entity.HasIndex(e => e.CmpCode, "CONSTITUER$LIEN_182_FK");

                entity.Property(e => e.MedDepotlegal)
                    .HasMaxLength(10)
                    .HasColumnName("MED_DEPOTLEGAL");

                entity.Property(e => e.CmpCode)
                    .HasMaxLength(4)
                    .HasColumnName("CMP_CODE");

                entity.Property(e => e.CstQte).HasColumnName("CST_QTE");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.CmpCodeNavigation)
                    .WithMany(p => p.Constituers)
                    .HasForeignKey(d => d.CmpCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONSTITUER${71FD2D72-0D6A-43C1-963B-3633406D704D}");

                entity.HasOne(d => d.MedDepotlegalNavigation)
                    .WithMany(p => p.Constituers)
                    .HasForeignKey(d => d.MedDepotlegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONSTITUER${C117FEE7-AA81-4F86-B5FE-F201F9F80B0D}");
            });

            modelBuilder.Entity<Dosage>(entity =>
            {
                entity.HasKey(e => e.DosCode)
                    .HasName("DOSAGE$DOSAGE_PK");

                entity.ToTable("DOSAGE");

                entity.Property(e => e.DosCode)
                    .HasMaxLength(10)
                    .HasColumnName("DOS_CODE");

                entity.Property(e => e.DosQuantite)
                    .HasMaxLength(10)
                    .HasColumnName("DOS_QUANTITE");

                entity.Property(e => e.DosUnite)
                    .HasMaxLength(10)
                    .HasColumnName("DOS_UNITE");
            });

            modelBuilder.Entity<Famille>(entity =>
            {
                entity.HasKey(e => e.FamCode)
                    .HasName("FAMILLE$FAMILLE_PK");

                entity.ToTable("FAMILLE");

                entity.Property(e => e.FamCode)
                    .HasMaxLength(3)
                    .HasColumnName("FAM_CODE");

                entity.Property(e => e.FamLibelle)
                    .HasMaxLength(80)
                    .HasColumnName("FAM_LIBELLE");
            });

            modelBuilder.Entity<Inviter>(entity =>
            {
                entity.HasKey(e => new { e.AcNum, e.PraNum })
                    .HasName("INVITER$INVITER_PK");

                entity.ToTable("INVITER");

                entity.HasIndex(e => e.AcNum, "INVITER$LIEN_37_FK");

                entity.HasIndex(e => e.PraNum, "INVITER$LIEN_38_FK");

                entity.Property(e => e.AcNum).HasColumnName("AC_NUM");

                entity.Property(e => e.PraNum).HasColumnName("PRA_NUM");

                entity.Property(e => e.Specialisteon)
                    .HasColumnName("SPECIALISTEON")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.AcNumNavigation)
                    .WithMany(p => p.Inviters)
                    .HasForeignKey(d => d.AcNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVITER${194BCE92-A8C4-4683-91C2-7B1CC0E48F1B}");

                entity.HasOne(d => d.PraNumNavigation)
                    .WithMany(p => p.Inviters)
                    .HasForeignKey(d => d.PraNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVITER${DEB1742C-B963-41D9-9F12-F7F65DC9FC18}");
            });

            modelBuilder.Entity<Labo>(entity =>
            {
                entity.HasKey(e => e.LabCode)
                    .HasName("LABO$DEPARTEMENT_PK");

                entity.ToTable("LABO");

                entity.Property(e => e.LabCode)
                    .HasMaxLength(2)
                    .HasColumnName("LAB_CODE");

                entity.Property(e => e.LabChefvente)
                    .HasMaxLength(20)
                    .HasColumnName("LAB_CHEFVENTE");

                entity.Property(e => e.LabNom)
                    .HasMaxLength(10)
                    .HasColumnName("LAB_NOM");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedDepotlegal)
                    .HasName("MEDICAMENT$MEDICAMENT_PK");

                entity.ToTable("MEDICAMENT");

                entity.HasIndex(e => e.FamCode, "MEDICAMENT$APPARTENIR_FK");

                entity.Property(e => e.MedDepotlegal)
                    .HasMaxLength(10)
                    .HasColumnName("MED_DEPOTLEGAL");

                entity.Property(e => e.FamCode)
                    .HasMaxLength(3)
                    .HasColumnName("FAM_CODE");

                entity.Property(e => e.MedComposition)
                    .HasMaxLength(255)
                    .HasColumnName("MED_COMPOSITION");

                entity.Property(e => e.MedContreindic)
                    .HasMaxLength(255)
                    .HasColumnName("MED_CONTREINDIC");

                entity.Property(e => e.MedEffets)
                    .HasMaxLength(255)
                    .HasColumnName("MED_EFFETS");

                entity.Property(e => e.MedNomcommercial)
                    .HasMaxLength(25)
                    .HasColumnName("MED_NOMCOMMERCIAL");

                entity.Property(e => e.MedPrixechantillon).HasColumnName("MED_PRIXECHANTILLON");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.FamCodeNavigation)
                    .WithMany(p => p.Medicaments)
                    .HasForeignKey(d => d.FamCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MEDICAMENT${413A5D74-85A8-45E7-B320-DF5E9396BAED}");

                entity.HasMany(d => d.MedMedPerturbes)
                    .WithMany(p => p.MedPerturbateurs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Interagir",
                        l => l.HasOne<Medicament>().WithMany().HasForeignKey("MedMedPerturbe").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("INTERAGIR${F32A801A-44C2-4AEB-8A0E-51396C6F3020}"),
                        r => r.HasOne<Medicament>().WithMany().HasForeignKey("MedPerturbateur").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("INTERAGIR${C1208A3D-F928-4436-AACF-376DDC7DA8F9}"),
                        j =>
                        {
                            j.HasKey("MedPerturbateur", "MedMedPerturbe").HasName("INTERAGIR$INTERAGIR_PK");

                            j.ToTable("INTERAGIR");

                            j.HasIndex(new[] { "MedMedPerturbe" }, "INTERAGIR$PERTURBATEUR_FK");

                            j.HasIndex(new[] { "MedPerturbateur" }, "INTERAGIR$PERTURBE_FK");

                            j.IndexerProperty<string>("MedPerturbateur").HasMaxLength(10).HasColumnName("MED_PERTURBATEUR");

                            j.IndexerProperty<string>("MedMedPerturbe").HasMaxLength(10).HasColumnName("MED_MED_PERTURBE");
                        });

                entity.HasMany(d => d.MedPerturbateurs)
                    .WithMany(p => p.MedMedPerturbes)
                    .UsingEntity<Dictionary<string, object>>(
                        "Interagir",
                        l => l.HasOne<Medicament>().WithMany().HasForeignKey("MedPerturbateur").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("INTERAGIR${C1208A3D-F928-4436-AACF-376DDC7DA8F9}"),
                        r => r.HasOne<Medicament>().WithMany().HasForeignKey("MedMedPerturbe").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("INTERAGIR${F32A801A-44C2-4AEB-8A0E-51396C6F3020}"),
                        j =>
                        {
                            j.HasKey("MedPerturbateur", "MedMedPerturbe").HasName("INTERAGIR$INTERAGIR_PK");

                            j.ToTable("INTERAGIR");

                            j.HasIndex(new[] { "MedMedPerturbe" }, "INTERAGIR$PERTURBATEUR_FK");

                            j.HasIndex(new[] { "MedPerturbateur" }, "INTERAGIR$PERTURBE_FK");

                            j.IndexerProperty<string>("MedPerturbateur").HasMaxLength(10).HasColumnName("MED_PERTURBATEUR");

                            j.IndexerProperty<string>("MedMedPerturbe").HasMaxLength(10).HasColumnName("MED_MED_PERTURBE");
                        });

                entity.HasMany(d => d.PreCodes)
                    .WithMany(p => p.MedDepotlegals)
                    .UsingEntity<Dictionary<string, object>>(
                        "Formuler",
                        l => l.HasOne<Presentation>().WithMany().HasForeignKey("PreCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FORMULER${1FA0425F-A30D-420E-9142-AB9EEA79ABAF}"),
                        r => r.HasOne<Medicament>().WithMany().HasForeignKey("MedDepotlegal").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FORMULER${35254FCA-17C5-4BED-ACE9-7A61C0B36749}"),
                        j =>
                        {
                            j.HasKey("MedDepotlegal", "PreCode").HasName("FORMULER$FORMULER_PK");

                            j.ToTable("FORMULER");

                            j.HasIndex(new[] { "MedDepotlegal" }, "FORMULER$LIEN_177_FK");

                            j.HasIndex(new[] { "PreCode" }, "FORMULER$LIEN_178_FK");

                            j.IndexerProperty<string>("MedDepotlegal").HasMaxLength(10).HasColumnName("MED_DEPOTLEGAL");

                            j.IndexerProperty<string>("PreCode").HasMaxLength(2).HasColumnName("PRE_CODE");
                        });
            });

            modelBuilder.Entity<Offrir>(entity =>
            {
                entity.HasKey(e => new { e.VisMatricule, e.RapNum, e.MedDepotlegal })
                    .HasName("OFFRIR$OFFRIR_PK");

                entity.ToTable("OFFRIR");

                entity.HasIndex(e => e.MedDepotlegal, "OFFRIR$LIEN_287_FK");

                entity.HasIndex(e => new { e.VisMatricule, e.RapNum }, "OFFRIR$LIEN_34_FK");

                entity.Property(e => e.VisMatricule)
                    .HasMaxLength(10)
                    .HasColumnName("VIS_MATRICULE");

                entity.Property(e => e.RapNum).HasColumnName("RAP_NUM");

                entity.Property(e => e.MedDepotlegal)
                    .HasMaxLength(10)
                    .HasColumnName("MED_DEPOTLEGAL");

                entity.Property(e => e.OffQte).HasColumnName("OFF_QTE");

                entity.HasOne(d => d.MedDepotlegalNavigation)
                    .WithMany(p => p.Offrirs)
                    .HasForeignKey(d => d.MedDepotlegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OFFRIR${212870AC-D285-4251-9654-14A416149517}");

                entity.HasOne(d => d.RapportVisite)
                    .WithMany(p => p.Offrirs)
                    .HasForeignKey(d => new { d.VisMatricule, d.RapNum })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OFFRIR${3A261F4F-9FED-418E-8FEE-E91583119C7E}");
            });

            modelBuilder.Entity<Posseder>(entity =>
            {
                entity.HasKey(e => new { e.PraNum, e.SpeCode })
                    .HasName("POSSEDER$POSSEDER_PK");

                entity.ToTable("POSSEDER");

                entity.HasIndex(e => e.PraNum, "POSSEDER$LIEN_125_FK");

                entity.HasIndex(e => e.SpeCode, "POSSEDER$LIEN_126_FK");

                entity.Property(e => e.PraNum).HasColumnName("PRA_NUM");

                entity.Property(e => e.SpeCode)
                    .HasMaxLength(5)
                    .HasColumnName("SPE_CODE");

                entity.Property(e => e.PosCoefprescription).HasColumnName("POS_COEFPRESCRIPTION");

                entity.Property(e => e.PosDiplome)
                    .HasMaxLength(10)
                    .HasColumnName("POS_DIPLOME");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.PraNumNavigation)
                    .WithMany(p => p.Posseders)
                    .HasForeignKey(d => d.PraNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POSSEDER${99960067-C04E-44F3-95AF-6F4F392F6347}");

                entity.HasOne(d => d.SpeCodeNavigation)
                    .WithMany(p => p.Posseders)
                    .HasForeignKey(d => d.SpeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POSSEDER${6F32033E-99CD-4486-8CE2-84644754DE3F}");
            });

            modelBuilder.Entity<Praticien>(entity =>
            {
                entity.HasKey(e => e.PraNum)
                    .HasName("PRATICIEN$PRATICIEN_PK");

                entity.ToTable("PRATICIEN");

                entity.HasIndex(e => e.TypCode, "PRATICIEN$RELEVER_FK");

                entity.Property(e => e.PraNum)
                    .ValueGeneratedNever()
                    .HasColumnName("PRA_NUM");

                entity.Property(e => e.PraAdresse)
                    .HasMaxLength(50)
                    .HasColumnName("PRA_ADRESSE");

                entity.Property(e => e.PraCoefnotoriete).HasColumnName("PRA_COEFNOTORIETE");

                entity.Property(e => e.PraCp)
                    .HasMaxLength(5)
                    .HasColumnName("PRA_CP");

                entity.Property(e => e.PraNom)
                    .HasMaxLength(25)
                    .HasColumnName("PRA_NOM");

                entity.Property(e => e.PraPrenom)
                    .HasMaxLength(30)
                    .HasColumnName("PRA_PRENOM");

                entity.Property(e => e.PraVille)
                    .HasMaxLength(25)
                    .HasColumnName("PRA_VILLE");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.TypCode)
                    .HasMaxLength(3)
                    .HasColumnName("TYP_CODE");

                entity.HasOne(d => d.TypCodeNavigation)
                    .WithMany(p => p.Praticiens)
                    .HasForeignKey(d => d.TypCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRATICIEN${1DD782AB-506C-441B-9E6D-7263FD1C1EAF}");
            });

            modelBuilder.Entity<Prescrire>(entity =>
            {
                entity.HasKey(e => new { e.MedDepotlegal, e.TinCode, e.DosCode })
                    .HasName("PRESCRIRE$PRESCRIRE_PK");

                entity.ToTable("PRESCRIRE");

                entity.HasIndex(e => e.MedDepotlegal, "PRESCRIRE$LIEN_174_FK");

                entity.HasIndex(e => e.TinCode, "PRESCRIRE$LIEN_175_FK");

                entity.HasIndex(e => e.DosCode, "PRESCRIRE$LIEN_176_FK");

                entity.Property(e => e.MedDepotlegal)
                    .HasMaxLength(10)
                    .HasColumnName("MED_DEPOTLEGAL");

                entity.Property(e => e.TinCode)
                    .HasMaxLength(5)
                    .HasColumnName("TIN_CODE");

                entity.Property(e => e.DosCode)
                    .HasMaxLength(10)
                    .HasColumnName("DOS_CODE");

                entity.Property(e => e.PrePosologie)
                    .HasMaxLength(40)
                    .HasColumnName("PRE_POSOLOGIE");

                entity.HasOne(d => d.DosCodeNavigation)
                    .WithMany(p => p.Prescrires)
                    .HasForeignKey(d => d.DosCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESCRIRE${C90A61AD-D8EF-48C0-8F11-39ADCC0CB9E6}");

                entity.HasOne(d => d.MedDepotlegalNavigation)
                    .WithMany(p => p.Prescrires)
                    .HasForeignKey(d => d.MedDepotlegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESCRIRE${02233D94-7C64-4199-B94D-8E272446F5A6}");

                entity.HasOne(d => d.TinCodeNavigation)
                    .WithMany(p => p.Prescrires)
                    .HasForeignKey(d => d.TinCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESCRIRE${2551EBD9-3594-4572-9B70-C3ADA46DC4AE}");
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasKey(e => e.PreCode)
                    .HasName("PRESENTATION$PRESENTATION_PK");

                entity.ToTable("PRESENTATION");

                entity.Property(e => e.PreCode)
                    .HasMaxLength(2)
                    .HasColumnName("PRE_CODE");

                entity.Property(e => e.PreLibelle)
                    .HasMaxLength(20)
                    .HasColumnName("PRE_LIBELLE");
            });

            modelBuilder.Entity<RapportVisite>(entity =>
            {
                entity.HasKey(e => new { e.VisMatricule, e.RapNum })
                    .HasName("RAPPORT_VISITE$RAPPORT_VISITE_PK");

                entity.ToTable("RAPPORT_VISITE");

                entity.HasIndex(e => e.PraNum, "RAPPORT_VISITE$CONCERNER_FK");

                entity.HasIndex(e => e.VisMatricule, "RAPPORT_VISITE$REDIGER_FK");

                entity.Property(e => e.VisMatricule)
                    .HasMaxLength(10)
                    .HasColumnName("VIS_MATRICULE");

                entity.Property(e => e.RapNum)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RAP_NUM");

                entity.Property(e => e.PraNum).HasColumnName("PRA_NUM");

                entity.Property(e => e.RapBilan)
                    .HasMaxLength(255)
                    .HasColumnName("RAP_BILAN");

                entity.Property(e => e.RapDate)
                    .HasPrecision(0)
                    .HasColumnName("RAP_DATE");

                entity.Property(e => e.RapMotif)
                    .HasMaxLength(255)
                    .HasColumnName("RAP_MOTIF");

                entity.HasOne(d => d.PraNumNavigation)
                    .WithMany(p => p.RapportVisites)
                    .HasForeignKey(d => d.PraNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RAPPORT_VISITE${8EE7B4B5-E509-4735-B4DF-9EF80AC6FA90}");

                entity.HasOne(d => d.VisMatriculeNavigation)
                    .WithMany(p => p.RapportVisites)
                    .HasForeignKey(d => d.VisMatricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RAPPORT_VISITE${C0C347FC-9646-4619-9E2A-572232AB4654}");
            });

            modelBuilder.Entity<Realiser>(entity =>
            {
                entity.HasKey(e => new { e.AcNum, e.VisMatricule })
                    .HasName("REALISER$REALISER_PK");

                entity.ToTable("REALISER");

                entity.HasIndex(e => e.AcNum, "REALISER$LIEN_36_FK");

                entity.HasIndex(e => e.VisMatricule, "REALISER$LIEN_39_FK");

                entity.Property(e => e.AcNum).HasColumnName("AC_NUM");

                entity.Property(e => e.VisMatricule)
                    .HasMaxLength(10)
                    .HasColumnName("VIS_MATRICULE");

                entity.Property(e => e.ReaMttfrais).HasColumnName("REA_MTTFRAIS");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.AcNumNavigation)
                    .WithMany(p => p.Realisers)
                    .HasForeignKey(d => d.AcNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REALISER${D1B87024-4384-43BC-9EC9-870194D4BD7B}");

                entity.HasOne(d => d.VisMatriculeNavigation)
                    .WithMany(p => p.Realisers)
                    .HasForeignKey(d => d.VisMatricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REALISER${E097CD3C-C67D-41B2-9249-8689FD140E16}");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegCode)
                    .HasName("REGION$REGION_PK");

                entity.ToTable("REGION");

                entity.HasIndex(e => e.SecCode, "REGION$RATTACHER_FK");

                entity.Property(e => e.RegCode)
                    .HasMaxLength(2)
                    .HasColumnName("REG_CODE");

                entity.Property(e => e.RegNom)
                    .HasMaxLength(50)
                    .HasColumnName("REG_NOM");

                entity.Property(e => e.SecCode)
                    .HasMaxLength(1)
                    .HasColumnName("SEC_CODE");

                entity.HasOne(d => d.SecCodeNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.SecCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REGION${2A8A348F-6D52-456B-B96A-7B966468977E}");
            });

            modelBuilder.Entity<Secteur>(entity =>
            {
                entity.HasKey(e => e.SecCode)
                    .HasName("SECTEUR$SECTEUR_PK");

                entity.ToTable("SECTEUR");

                entity.Property(e => e.SecCode)
                    .HasMaxLength(1)
                    .HasColumnName("SEC_CODE");

                entity.Property(e => e.SecLibelle)
                    .HasMaxLength(15)
                    .HasColumnName("SEC_LIBELLE");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.SpeCode)
                    .HasName("SPECIALITE$SPECIALITE_PK");

                entity.ToTable("SPECIALITE");

                entity.Property(e => e.SpeCode)
                    .HasMaxLength(5)
                    .HasColumnName("SPE_CODE");

                entity.Property(e => e.SpeLibelle)
                    .HasMaxLength(150)
                    .HasColumnName("SPE_LIBELLE");
            });

            modelBuilder.Entity<SwitchboardItem>(entity =>
            {
                entity.HasKey(e => new { e.SwitchboardId, e.ItemNumber })
                    .HasName("Switchboard Items$PrimaryKey");

                entity.ToTable("Switchboard Items");

                entity.Property(e => e.SwitchboardId).HasColumnName("SwitchboardID");

                entity.Property(e => e.Argument).HasMaxLength(255);

                entity.Property(e => e.ItemText).HasMaxLength(255);
            });

            modelBuilder.Entity<Travailler>(entity =>
            {
                entity.HasKey(e => new { e.Jjmmaa, e.VisMatricule, e.RegCode })
                    .HasName("TRAVAILLER$TRAVAILLER_PK");

                entity.ToTable("TRAVAILLER");

                entity.HasIndex(e => e.VisMatricule, "TRAVAILLER$LIEN_77_FK");

                entity.HasIndex(e => e.RegCode, "TRAVAILLER$LIEN_78_FK");

                entity.Property(e => e.Jjmmaa)
                    .HasPrecision(0)
                    .HasColumnName("JJMMAA");

                entity.Property(e => e.VisMatricule)
                    .HasMaxLength(10)
                    .HasColumnName("VIS_MATRICULE");

                entity.Property(e => e.RegCode)
                    .HasMaxLength(2)
                    .HasColumnName("REG_CODE");

                entity.Property(e => e.TraRole)
                    .HasMaxLength(11)
                    .HasColumnName("TRA_ROLE");

                entity.HasOne(d => d.RegCodeNavigation)
                    .WithMany(p => p.Travaillers)
                    .HasForeignKey(d => d.RegCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRAVAILLER${4019F059-649A-477C-B52B-8191CA9E7AD2}");

                entity.HasOne(d => d.VisMatriculeNavigation)
                    .WithMany(p => p.Travaillers)
                    .HasForeignKey(d => d.VisMatricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRAVAILLER${A35E8696-CF02-4BA8-BD16-753CD7E91075}");
            });

            modelBuilder.Entity<TypeIndividu>(entity =>
            {
                entity.HasKey(e => e.TinCode)
                    .HasName("TYPE_INDIVIDU$PrimaryKey");

                entity.ToTable("TYPE_INDIVIDU");

                entity.HasIndex(e => e.TinCode, "TYPE_INDIVIDU$TIN_CODE");

                entity.Property(e => e.TinCode)
                    .HasMaxLength(5)
                    .HasColumnName("TIN_CODE");

                entity.Property(e => e.TinLibelle)
                    .HasMaxLength(50)
                    .HasColumnName("TIN_LIBELLE");
            });

            modelBuilder.Entity<TypePraticien>(entity =>
            {
                entity.HasKey(e => e.TypCode)
                    .HasName("TYPE_PRATICIEN$TYPE_PRATICIEN_PK");

                entity.ToTable("TYPE_PRATICIEN");

                entity.Property(e => e.TypCode)
                    .HasMaxLength(3)
                    .HasColumnName("TYP_CODE");

                entity.Property(e => e.TypLibelle)
                    .HasMaxLength(25)
                    .HasColumnName("TYP_LIBELLE");

                entity.Property(e => e.TypLieu)
                    .HasMaxLength(35)
                    .HasColumnName("TYP_LIEU");
            });

            modelBuilder.Entity<Visiteur>(entity =>
            {
                entity.HasKey(e => e.VisMatricule)
                    .HasName("VISITEUR$VISITEUR_PK");

                entity.ToTable("VISITEUR");

                entity.HasIndex(e => e.LabCode, "VISITEUR$DEPENDRE_FK");

                entity.HasIndex(e => e.SecCode, "VISITEUR$SEC_CODE");

                entity.Property(e => e.VisMatricule)
                    .HasMaxLength(10)
                    .HasColumnName("VIS_MATRICULE");

                entity.Property(e => e.LabCode)
                    .HasMaxLength(2)
                    .HasColumnName("LAB_CODE");

                entity.Property(e => e.SecCode)
                    .HasMaxLength(1)
                    .HasColumnName("SEC_CODE");

                entity.Property(e => e.VisAdresse)
                    .HasMaxLength(50)
                    .HasColumnName("VIS_ADRESSE");

                entity.Property(e => e.VisCp)
                    .HasMaxLength(5)
                    .HasColumnName("VIS_CP");

                entity.Property(e => e.VisDateembauche)
                    .HasPrecision(0)
                    .HasColumnName("VIS_DATEEMBAUCHE");

                entity.Property(e => e.VisNom)
                    .HasMaxLength(25)
                    .HasColumnName("VIS_NOM");

                entity.Property(e => e.VisPrenom)
                    .HasMaxLength(50)
                    .HasColumnName("Vis_PRENOM");

                entity.Property(e => e.VisVille)
                    .HasMaxLength(30)
                    .HasColumnName("VIS_VILLE");

                entity.HasOne(d => d.LabCodeNavigation)
                    .WithMany(p => p.Visiteurs)
                    .HasForeignKey(d => d.LabCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VISITEUR${8D9C46F6-2643-4448-B555-9E5C85169BA4}");

                entity.HasOne(d => d.SecCodeNavigation)
                    .WithMany(p => p.Visiteurs)
                    .HasForeignKey(d => d.SecCode)
                    .HasConstraintName("VISITEUR${E2A4EA82-136A-4528-A19A-094497A7BBE0}");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
