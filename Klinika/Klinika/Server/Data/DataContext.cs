using Klinika.Shared;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<Odeljenje> Odeljenja { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odeljenje>().HasData(
                new Odeljenje
                {
                    Id = 1,
                    Naziv = "Kardiologija",
                    Url = "Kardiologija"
                },
                new Odeljenje
                {
                     Id = 2,
                     Naziv = "Stomatolog",
                     Url = "Stomatolog"
                }

                );

            modelBuilder.Entity<Doktor>().HasData(
                new Doktor
                {
                    Id = 1,
                    Ime = "Bojana",
                    Prezime = "Maksimovic",
                    BrojTelefona = "066654825",
                    OdeljenjeId = 1
                },
                new Doktor
                {
                    Id = 2,
                    Ime = "Nenad",
                    Prezime = "Stojakovic",
                    BrojTelefona = "063224433",
                    OdeljenjeId = 2
                }
                );

            modelBuilder.Entity<Pacijent>().HasData(
                new Pacijent
                {
                    Id = 1,
                    Ime = "Denis",
                    Prezime = "Fijuljanin"
                },
                new Pacijent
                {
                    Id = 2,
                    Ime = "Merisa",
                    Prezime = "Curic"
                }
                );
        }
    }
}
