namespace ProjektWojsko.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnection : DbContext
    {
        public DBConnection()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<HISTORIA_NAPRAW> HISTORIA_NAPRAW { get; set; }
        public virtual DbSet<HISTORIA_SPRZETU> HISTORIA_SPRZETU { get; set; }
        public virtual DbSet<JEDNOSTKA_ORGANIZACYJNA> JEDNOSTKA_ORGANIZACYJNA { get; set; }
        public virtual DbSet<JEDNOSTKA_WOJSKOWA> JEDNOSTKA_WOJSKOWA { get; set; }
        public virtual DbSet<MISJA> MISJA { get; set; }
        public virtual DbSet<MISJA_OSOBA> MISJA_OSOBA { get; set; }
        public virtual DbSet<MISJA_SPRZET_WOJSKOWY> MISJA_SPRZET_WOJSKOWY { get; set; }
        public virtual DbSet<OSOBA> OSOBA { get; set; }
        public virtual DbSet<POJAZD> POJAZD { get; set; }
        public virtual DbSet<PRZEGLAD> PRZEGLAD { get; set; }
        public virtual DbSet<SPRZET_WOJSKOWY> SPRZET_WOJSKOWY { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JEDNOSTKA_ORGANIZACYJNA>()
                .HasMany(e => e.JEDNOSTKA_ORGANIZACYJNA1)
                .WithOptional(e => e.JEDNOSTKA_ORGANIZACYJNA2)
                .HasForeignKey(e => e.ID_JEDNOSTKA_ORGANIZACYJNA);

            modelBuilder.Entity<JEDNOSTKA_ORGANIZACYJNA>()
                .HasMany(e => e.OSOBA)
                .WithOptional(e => e.JEDNOSTKA_ORGANIZACYJNA)
                .HasForeignKey(e => e.ID_JEDNOSTKA_ORGANIZACYJNA);

            modelBuilder.Entity<JEDNOSTKA_ORGANIZACYJNA>()
                .HasMany(e => e.SPRZET_WOJSKOWY)
                .WithRequired(e => e.JEDNOSTKA_ORGANIZACYJNA)
                .HasForeignKey(e => e.ID_JEDNOSTKA_ORGANIZACYJNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JEDNOSTKA_WOJSKOWA>()
                .HasMany(e => e.JEDNOSTKA_ORGANIZACYJNA)
                .WithRequired(e => e.JEDNOSTKA_WOJSKOWA)
                .HasForeignKey(e => e.ID_JEDNOSTKA_WOJSKOWA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MISJA>()
                .HasMany(e => e.MISJA_OSOBA)
                .WithRequired(e => e.MISJA)
                .HasForeignKey(e => e.ID_MISJA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MISJA>()
                .HasMany(e => e.MISJA_SPRZET_WOJSKOWY)
                .WithRequired(e => e.MISJA)
                .HasForeignKey(e => e.MISJA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OSOBA>()
                .Property(e => e.IMIE)
                .IsUnicode(false);

            modelBuilder.Entity<OSOBA>()
                .HasMany(e => e.HISTORIA_SPRZETU)
                .WithRequired(e => e.OSOBA)
                .HasForeignKey(e => e.ID_OSOBA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OSOBA>()
                .HasMany(e => e.MISJA_OSOBA)
                .WithRequired(e => e.OSOBA)
                .HasForeignKey(e => e.ID_OSOBA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OSOBA>()
                .HasMany(e => e.OSOBA1)
                .WithOptional(e => e.OSOBA2)
                .HasForeignKey(e => e.ID_OSOBA);

            modelBuilder.Entity<OSOBA>()
                .HasMany(e => e.POJAZD)
                .WithRequired(e => e.OSOBA)
                .HasForeignKey(e => e.ID_OSOBA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POJAZD>()
                .HasMany(e => e.HISTORIA_NAPRAW)
                .WithRequired(e => e.POJAZD)
                .HasForeignKey(e => e.ID_POJAZD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRZEGLAD>()
                .HasMany(e => e.HISTORIA_NAPRAW)
                .WithRequired(e => e.PRZEGLAD)
                .HasForeignKey(e => e.ID_PRZEGLAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPRZET_WOJSKOWY>()
                .HasMany(e => e.HISTORIA_SPRZETU)
                .WithRequired(e => e.SPRZET_WOJSKOWY)
                .HasForeignKey(e => e.ID_SPRZET_WOJSKOWY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SPRZET_WOJSKOWY>()
                .HasMany(e => e.MISJA_SPRZET_WOJSKOWY)
                .WithRequired(e => e.SPRZET_WOJSKOWY)
                .HasForeignKey(e => e.SPRZET_WOJSKOWY_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
