﻿// <auto-generated />
using System;
using Firma.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Firma.Data.Migrations
{
    [DbContext(typeof(FirmaDbContext))]
    [Migration("20230111142113_dd")]
    partial class dd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Firma.Data.Model.Adres", b =>
                {
                    b.Property<int>("IdAdresu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdresu"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<bool>("Glowny")
                        .HasColumnType("bit");

                    b.Property<int>("IdKontrahenta")
                        .HasColumnType("int");

                    b.Property<string>("KodPoczowy")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Kraj")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Miejscowosc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NrDomu")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NrLokalu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poczta")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Siedziba")
                        .HasColumnType("bit");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAdresu");

                    b.HasIndex("IdKontrahenta");

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("Firma.Data.Model.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<string>("IdSession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Ilosc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduktu");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("Firma.Data.Model.Cena", b =>
                {
                    b.Property<int>("IdCeny")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCeny"));

                    b.Property<bool>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<int>("IdTypuCeny")
                        .HasColumnType("int");

                    b.Property<string>("Waluta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Wartosc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCeny");

                    b.HasIndex("IdProduktu");

                    b.HasIndex("IdTypuCeny");

                    b.ToTable("Ceny");
                });

            modelBuilder.Entity("Firma.Data.Model.Kontrahent", b =>
                {
                    b.Property<int>("IdKontrahenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKontrahenta"));

                    b.Property<string>("Akronim")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<int>("IdSposobuPlatnosci")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nip")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdKontrahenta");

                    b.HasIndex("IdSposobuPlatnosci");

                    b.ToTable("Kontrahenci");
                });

            modelBuilder.Entity("Firma.Data.Model.Monter", b =>
                {
                    b.Property<int>("IdMontera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMontera"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMontera");

                    b.ToTable("Monterzy");
                });

            modelBuilder.Entity("Firma.Data.Model.PozycjaZZ", b =>
                {
                    b.Property<int>("IdPozycjiZleceniaZakupu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPozycjiZleceniaZakupu"));

                    b.Property<bool>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<int>("IdZleceniaZakupu")
                        .HasColumnType("int");

                    b.Property<decimal>("Ilosc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rabat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPozycjiZleceniaZakupu");

                    b.HasIndex("IdProduktu");

                    b.HasIndex("IdZleceniaZakupu");

                    b.ToTable("PozycjeZleceniaZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.Produkt", b =>
                {
                    b.Property<int>("IdProduktu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduktu"));

                    b.Property<int?>("CzasKompletacji")
                        .HasColumnType("int");

                    b.Property<bool>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("DodatkowaNazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDostawcy")
                        .HasColumnType("int");

                    b.Property<int>("IdTypu")
                        .HasColumnType("int");

                    b.Property<string>("JednostkaMiary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPcn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kraj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OdwrotneObciazenie")
                        .HasColumnType("bit");

                    b.Property<bool>("PodzielonaPlatnosc")
                        .HasColumnType("bit");

                    b.Property<string>("Producent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SWW_PKWiU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("StawkaCla")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StawkaVatSprzedazy")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StawkaVatZakupu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StwkaAkcyzy")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProduktu");

                    b.HasIndex("IdDostawcy");

                    b.HasIndex("IdTypu");

                    b.ToTable("Produkty");
                });

            modelBuilder.Entity("Firma.Data.Model.ProduktUbocznyZK", b =>
                {
                    b.Property<int>("IdPrUbocznego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrUbocznego"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<int?>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<int>("IdZleceniaKompletacji")
                        .HasColumnType("int");

                    b.Property<decimal>("Ilosc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPrUbocznego");

                    b.HasIndex("IdProduktu");

                    b.HasIndex("IdZleceniaKompletacji");

                    b.ToTable("PrUboczneZleceniaKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.RodzajTransportu", b =>
                {
                    b.Property<int>("IdRodzajuTransportu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRodzajuTransportu"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRodzajuTransportu");

                    b.ToTable("RodzajeTransportu");
                });

            modelBuilder.Entity("Firma.Data.Model.SkladnikZK", b =>
                {
                    b.Property<int>("IdSkladnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSkladnika"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<int?>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<int>("IdZleceniaKompletacji")
                        .HasColumnType("int");

                    b.Property<decimal>("Ilosc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdSkladnika");

                    b.HasIndex("IdProduktu");

                    b.HasIndex("IdZleceniaKompletacji");

                    b.ToTable("SkładnikiZleceniaKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.SposobDostawy", b =>
                {
                    b.Property<int>("IdSposobuDostawy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSposobuDostawy"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSposobuDostawy");

                    b.ToTable("SposobyDostawy");
                });

            modelBuilder.Entity("Firma.Data.Model.SposobPlatnosci", b =>
                {
                    b.Property<int>("IdSposobuPlatnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSposobuPlatnosci"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSposobuPlatnosci");

                    b.ToTable("SposobyPlatnosci");
                });

            modelBuilder.Entity("Firma.Data.Model.TypCeny", b =>
                {
                    b.Property<int>("IdTypuCeny")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypuCeny"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypuCeny");

                    b.ToTable("TypyCen");
                });

            modelBuilder.Entity("Firma.Data.Model.TypProduktu", b =>
                {
                    b.Property<int>("IdTypuProduktu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypuProduktu"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<bool>("CzySklep")
                        .HasColumnType("bit");

                    b.Property<string>("FotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypuProduktu");

                    b.ToTable("TypyProduktow");
                });

            modelBuilder.Entity("Firma.Data.Model.TypTransakcji", b =>
                {
                    b.Property<int>("IdTypuTransakcji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypuTransakcji"));

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypuTransakcji");

                    b.ToTable("TypyTransakcji");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieKompletacji", b =>
                {
                    b.Property<int>("IdZleceniaKompletacji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZleceniaKompletacji"));

                    b.Property<int?>("CzasZlecenia")
                        .HasColumnType("int");

                    b.Property<bool>("CzyAktywne")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataWystawienia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKontrahenta")
                        .HasColumnType("int");

                    b.Property<int?>("IdMontera")
                        .HasColumnType("int");

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<decimal>("Ilosc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OczekiwanaDataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PotwierdzonaDataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Priorytet")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZleceniaKompletacji");

                    b.HasIndex("IdKontrahenta");

                    b.HasIndex("IdMontera");

                    b.HasIndex("IdProduktu");

                    b.ToTable("ZleceniaKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieZakupu", b =>
                {
                    b.Property<int>("IdZleceniaZakupu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZleceniaZakupu"));

                    b.Property<bool>("CzyAktywne")
                        .HasColumnType("bit");

                    b.Property<bool>("CzyPotwierdzone")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataWystawienia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKontrahenta")
                        .HasColumnType("int");

                    b.Property<int>("IdRodzajuTransportu")
                        .HasColumnType("int");

                    b.Property<int>("IdSposobuDostawy")
                        .HasColumnType("int");

                    b.Property<int>("IdSposobuPlatnosci")
                        .HasColumnType("int");

                    b.Property<int>("IdTransakcji")
                        .HasColumnType("int");

                    b.Property<string>("NrOferty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrPotwierdzenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalOrder")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdZleceniaZakupu");

                    b.HasIndex("IdKontrahenta");

                    b.HasIndex("IdRodzajuTransportu");

                    b.HasIndex("IdSposobuDostawy");

                    b.HasIndex("IdSposobuPlatnosci");

                    b.HasIndex("IdTransakcji");

                    b.ToTable("ZleceniaZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.Adres", b =>
                {
                    b.HasOne("Firma.Data.Model.Kontrahent", "Kontrahent")
                        .WithMany("Adres")
                        .HasForeignKey("IdKontrahenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kontrahent");
                });

            modelBuilder.Entity("Firma.Data.Model.CartItem", b =>
                {
                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("IdProduktu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Firma.Data.Model.Cena", b =>
                {
                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany("Cena")
                        .HasForeignKey("IdProduktu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.TypCeny", "TypCeny")
                        .WithMany("Cena")
                        .HasForeignKey("IdTypuCeny")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("TypCeny");
                });

            modelBuilder.Entity("Firma.Data.Model.Kontrahent", b =>
                {
                    b.HasOne("Firma.Data.Model.SposobPlatnosci", "SposobPlatnosci")
                        .WithMany("Kontrahent")
                        .HasForeignKey("IdSposobuPlatnosci")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SposobPlatnosci");
                });

            modelBuilder.Entity("Firma.Data.Model.PozycjaZZ", b =>
                {
                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany("PozycjaZZ")
                        .HasForeignKey("IdProduktu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.ZlecenieZakupu", "ZlecenieZakupu")
                        .WithMany("PozycjaZZ")
                        .HasForeignKey("IdZleceniaZakupu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("ZlecenieZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.Produkt", b =>
                {
                    b.HasOne("Firma.Data.Model.Kontrahent", "Dostawca")
                        .WithMany()
                        .HasForeignKey("IdDostawcy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.TypProduktu", "TypProduktu")
                        .WithMany("Produkt")
                        .HasForeignKey("IdTypu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dostawca");

                    b.Navigation("TypProduktu");
                });

            modelBuilder.Entity("Firma.Data.Model.ProduktUbocznyZK", b =>
                {
                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany("ProduktUbocznyZK")
                        .HasForeignKey("IdProduktu");

                    b.HasOne("Firma.Data.Model.ZlecenieKompletacji", "ZlecenieKompletacji")
                        .WithMany("ProduktUbocznyZK")
                        .HasForeignKey("IdZleceniaKompletacji")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("ZlecenieKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.SkladnikZK", b =>
                {
                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany("SkladnikZK")
                        .HasForeignKey("IdProduktu");

                    b.HasOne("Firma.Data.Model.ZlecenieKompletacji", "ZlecenieKompletacji")
                        .WithMany("SkladnikZK")
                        .HasForeignKey("IdZleceniaKompletacji")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("ZlecenieKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieKompletacji", b =>
                {
                    b.HasOne("Firma.Data.Model.Kontrahent", "Kontrahent")
                        .WithMany()
                        .HasForeignKey("IdKontrahenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.Monter", "Monter")
                        .WithMany("ZlecenieKompletacji")
                        .HasForeignKey("IdMontera");

                    b.HasOne("Firma.Data.Model.Produkt", "Produkt")
                        .WithMany("ZlecenieKompletacji")
                        .HasForeignKey("IdProduktu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kontrahent");

                    b.Navigation("Monter");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieZakupu", b =>
                {
                    b.HasOne("Firma.Data.Model.Kontrahent", "Kontrahent")
                        .WithMany()
                        .HasForeignKey("IdKontrahenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.RodzajTransportu", "RodzajTransportu")
                        .WithMany("ZlecenieZakupu")
                        .HasForeignKey("IdRodzajuTransportu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.SposobDostawy", "SposobDostawy")
                        .WithMany("ZlecenieZakupu")
                        .HasForeignKey("IdSposobuDostawy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.SposobPlatnosci", "SposobPlatnosci")
                        .WithMany("ZlecenieZakupu")
                        .HasForeignKey("IdSposobuPlatnosci")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firma.Data.Model.TypTransakcji", "TypTransakcji")
                        .WithMany("ZlecenieZakupu")
                        .HasForeignKey("IdTransakcji")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kontrahent");

                    b.Navigation("RodzajTransportu");

                    b.Navigation("SposobDostawy");

                    b.Navigation("SposobPlatnosci");

                    b.Navigation("TypTransakcji");
                });

            modelBuilder.Entity("Firma.Data.Model.Kontrahent", b =>
                {
                    b.Navigation("Adres");
                });

            modelBuilder.Entity("Firma.Data.Model.Monter", b =>
                {
                    b.Navigation("ZlecenieKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.Produkt", b =>
                {
                    b.Navigation("Cena");

                    b.Navigation("PozycjaZZ");

                    b.Navigation("ProduktUbocznyZK");

                    b.Navigation("SkladnikZK");

                    b.Navigation("ZlecenieKompletacji");
                });

            modelBuilder.Entity("Firma.Data.Model.RodzajTransportu", b =>
                {
                    b.Navigation("ZlecenieZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.SposobDostawy", b =>
                {
                    b.Navigation("ZlecenieZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.SposobPlatnosci", b =>
                {
                    b.Navigation("Kontrahent");

                    b.Navigation("ZlecenieZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.TypCeny", b =>
                {
                    b.Navigation("Cena");
                });

            modelBuilder.Entity("Firma.Data.Model.TypProduktu", b =>
                {
                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Firma.Data.Model.TypTransakcji", b =>
                {
                    b.Navigation("ZlecenieZakupu");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieKompletacji", b =>
                {
                    b.Navigation("ProduktUbocznyZK");

                    b.Navigation("SkladnikZK");
                });

            modelBuilder.Entity("Firma.Data.Model.ZlecenieZakupu", b =>
                {
                    b.Navigation("PozycjaZZ");
                });
#pragma warning restore 612, 618
        }
    }
}
