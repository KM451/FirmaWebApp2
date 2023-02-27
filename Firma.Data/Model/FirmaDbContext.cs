using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Model
{
    public class FirmaDbContext: DbContext
    {
        public FirmaDbContext(DbContextOptions<FirmaDbContext> options): base(options) {}

        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
        public DbSet<Monter> Monterzy { get; set; }
        public DbSet<PozycjaZZ> PozycjeZleceniaZakupu { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<ProduktUbocznyZK> PrUboczneZleceniaKompletacji { get; set; }
        public DbSet<RodzajTransportu> RodzajeTransportu { get; set; }
        public DbSet<SkladnikZK> SkładnikiZleceniaKompletacji { get; set; }
        public DbSet<SposobDostawy> SposobyDostawy { get; set; }
        public DbSet<SposobPlatnosci> SposobyPlatnosci { get; set; }
        public DbSet<TypCeny> TypyCen { get; set; }
        public DbSet<TypProduktu> TypyProduktow { get; set; }
        public DbSet<TypTransakcji> TypyTransakcji { get; set; }
        public DbSet<Cena> Ceny { get; set; }
        public DbSet<ZlecenieKompletacji> ZleceniaKompletacji { get; set; }
        public DbSet<ZlecenieZakupu> ZleceniaZakupu { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }
}
