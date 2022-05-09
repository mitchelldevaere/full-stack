using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TicketModels.Entities;

namespace TicketModels.Data
{
    public partial class TicketVerkoopDbContext : DbContext
    {
        public TicketVerkoopDbContext()
        {
        }

        public TicketVerkoopDbContext(DbContextOptions<TicketVerkoopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abbonement> Abbonements { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Plaat> Plaats { get; set; } = null!;
        public virtual DbSet<Ploeg> Ploegs { get; set; } = null!;
        public virtual DbSet<Reservering> Reserverings { get; set; } = null!;
        public virtual DbSet<Seizoen> Seizoens { get; set; } = null!;
        public virtual DbSet<Stadion> Stadions { get; set; } = null!;
        public virtual DbSet<Vak> Vaks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQL19_VIVES; Database=TicketVerkoop; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abbonement>(entity =>
            {
                entity.ToTable("Abbonement");

                entity.Property(e => e.AbbonementId).HasColumnName("AbbonementID");

                entity.Property(e => e.PloegId).HasColumnName("PloegID");

                entity.Property(e => e.SeizoenId).HasColumnName("SeizoenID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Ploeg)
                    .WithMany(p => p.Abbonements)
                    .HasForeignKey(d => d.PloegId)
                    .HasConstraintName("FK_Abbonement_Ploeg");

                entity.HasOne(d => d.Seizoen)
                    .WithMany(p => p.Abbonements)
                    .HasForeignKey(d => d.SeizoenId)
                    .HasConstraintName("FK_Abbonement_Seizoen");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.Property(e => e.ThuisploegId).HasColumnName("ThuisploegID");

                entity.Property(e => e.UitploegId).HasColumnName("UitploegID");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Stadion");

                entity.HasOne(d => d.Thuisploeg)
                    .WithMany(p => p.MatchThuisploegs)
                    .HasForeignKey(d => d.ThuisploegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Ploeg");

                entity.HasOne(d => d.Uitploeg)
                    .WithMany(p => p.MatchUitploegs)
                    .HasForeignKey(d => d.UitploegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Ploeg1");
            });

            modelBuilder.Entity<Plaat>(entity =>
            {
                entity.HasKey(e => e.PlaatsId);

                entity.Property(e => e.PlaatsId).HasColumnName("PlaatsID");

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.Property(e => e.VakId).HasColumnName("VakID");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Plaats)
                    .HasForeignKey(d => d.StadionId)
                    .HasConstraintName("FK_Plaats_Stadion");

                entity.HasOne(d => d.Vak)
                    .WithMany(p => p.Plaats)
                    .HasForeignKey(d => d.VakId)
                    .HasConstraintName("FK_Plaats_Vak");
            });

            modelBuilder.Entity<Ploeg>(entity =>
            {
                entity.ToTable("Ploeg");

                entity.Property(e => e.PloegId).HasColumnName("PloegID");

                entity.Property(e => e.PloegNaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Ploegs)
                    .HasForeignKey(d => d.StadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ploeg_Stadion");
            });

            modelBuilder.Entity<Reservering>(entity =>
            {
                entity.ToTable("Reservering");

                entity.Property(e => e.ReserveringId).HasColumnName("ReserveringID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.PlaatsId).HasColumnName("PlaatsID");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.AbbonnementNavigation)
                    .WithMany(p => p.Reserverings)
                    .HasForeignKey(d => d.Abbonnement)
                    .HasConstraintName("FK_Reservering_Abbonement");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Reserverings)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Reservering_Match");

                entity.HasOne(d => d.Plaats)
                    .WithMany(p => p.Reserverings)
                    .HasForeignKey(d => d.PlaatsId)
                    .HasConstraintName("FK_Reservering_Plaats");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reserverings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Reservering_AspNetUsers");
            });

            modelBuilder.Entity<Seizoen>(entity =>
            {
                entity.ToTable("Seizoen");

                entity.Property(e => e.SeizoenId).HasColumnName("SeizoenID");

                entity.Property(e => e.BeginDatum).HasColumnType("datetime");

                entity.Property(e => e.EindDatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<Stadion>(entity =>
            {
                entity.ToTable("Stadion");

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.Property(e => e.PloegId).HasColumnName("PloegID");

                entity.Property(e => e.StadionNaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vak>(entity =>
            {
                entity.ToTable("Vak");

                entity.Property(e => e.VakId).HasColumnName("VakID");

                entity.Property(e => e.Prijs).HasColumnName("prijs");

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.Property(e => e.VakNaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Vaks)
                    .HasForeignKey(d => d.StadionId)
                    .HasConstraintName("FK_Vak_Stadion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
