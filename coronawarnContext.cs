using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoronaWarn
{
    public partial class coronawarnContext : DbContext
    {
        public coronawarnContext()
        {
        }

        //DB Context using the connection string for the two different tables
        public coronawarnContext(DbContextOptions<coronawarnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benutzer> Benutzers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //laut stackoverflow muss das rausgeschmissen werden
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=tcp:dhbw-devis.database.windows.net,1433;Initial Catalog=corona-warn;Persist Security Info=False;User ID=default;Password=Stuttgart97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Benutzer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.ToTable("Benutzer");

                entity.Property(e => e.Bis).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GebDat).HasColumnType("date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ort)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Seit).HasColumnType("date");

                entity.Property(e => e.Straße)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.ToTable("Location");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
