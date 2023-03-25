using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AltGorev> AltGorevs { get; set; } = null!;
        public virtual DbSet<Gorev> Gorevs { get; set; } = null!;
        public virtual DbSet<GorevKategori> GorevKategoris { get; set; } = null!;
        public virtual DbSet<GorevNot> GorevNots { get; set; } = null!;
        public virtual DbSet<Kullanici> Kullanicis { get; set; } = null!;
        public virtual DbSet<Proje> Projes { get; set; } = null!;
        public virtual DbSet<ProjeMaliyet> ProjeMaliyets { get; set; } = null!;
        public virtual DbSet<ProjeNot> ProjeNots { get; set; } = null!;
        public virtual DbSet<ProjeTeknoloji> ProjeTeknolojis { get; set; } = null!;
        public virtual DbSet<Teknoloji> Teknolojis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;User Id=sa;Password=Ferdicuyar1903;Database=ProjeYonetimdb;Max Pool Size=1000;MultipleActiveResultSets=True;Connection Timeout=500;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltGorev>(entity =>
            {
                entity.HasOne(d => d.Gorev)
                    .WithMany(p => p.AltGorevs)
                    .HasForeignKey(d => d.GorevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AltGorev_Gorev");
            });

            modelBuilder.Entity<Gorev>(entity =>
            {
                entity.HasOne(d => d.GorevSahibi)
                    .WithMany(p => p.Gorevs)
                    .HasForeignKey(d => d.GorevSahibiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gorev_Kullanici");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Gorevs)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Gorev_GorevKategori");

                entity.HasOne(d => d.Proje)
                    .WithMany(p => p.Gorevs)
                    .HasForeignKey(d => d.ProjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gorev_Proje");
            });

            modelBuilder.Entity<GorevNot>(entity =>
            {
                entity.HasOne(d => d.Gorev)
                    .WithMany(p => p.GorevNots)
                    .HasForeignKey(d => d.GorevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GorevNot_Gorev");

                entity.HasOne(d => d.NotSahibi)
                    .WithMany(p => p.GorevNots)
                    .HasForeignKey(d => d.NotSahibiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GorevNot_Kullanici");
            });

            modelBuilder.Entity<Proje>(entity =>
            {
                entity.HasOne(d => d.ProjeSahibi)
                    .WithMany(p => p.Projes)
                    .HasForeignKey(d => d.ProjeSahibiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proje_Kullanici");
            });

            modelBuilder.Entity<ProjeMaliyet>(entity =>
            {
                entity.HasOne(d => d.Proje)
                    .WithMany(p => p.ProjeMaliyets)
                    .HasForeignKey(d => d.ProjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjeMaliyet_Proje");
            });

            modelBuilder.Entity<ProjeNot>(entity =>
            {
                entity.HasOne(d => d.Kullanic)
                    .WithMany(p => p.ProjeNots)
                    .HasForeignKey(d => d.KullanicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjeNot_Kullanici");

                entity.HasOne(d => d.Proje)
                    .WithMany(p => p.ProjeNots)
                    .HasForeignKey(d => d.ProjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjeNot_Proje");
            });

            modelBuilder.Entity<ProjeTeknoloji>(entity =>
            {
                entity.HasOne(d => d.Proje)
                    .WithMany(p => p.ProjeTeknolojis)
                    .HasForeignKey(d => d.ProjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjeTeknoloji_Proje");

                entity.HasOne(d => d.Teknoloji)
                    .WithMany(p => p.ProjeTeknolojis)
                    .HasForeignKey(d => d.TeknolojiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjeTeknoloji_Teknoloji");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
