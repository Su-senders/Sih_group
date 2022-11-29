﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sih.Persistence.Configurations;

namespace Sih.Persistence.Configurations.Migrations
{
    [DbContext(typeof(SihDbContext))]
    partial class SihDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sih.Entities.Administration.NotificationsEntity", b =>
                {
                    b.Property<int>("NotificationsEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationsEntityId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Sih.Entities.Administration.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NomPrenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.InscriptionEntity", b =>
                {
                    b.Property<int>("InscriptionEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateIns")
                        .HasColumnType("datetime2");

                    b.Property<int>("EncadreurEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.Property<int>("Etatpaiement")
                        .HasColumnType("int");

                    b.Property<int>("HadjEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Standing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsagerEntityId")
                        .HasColumnType("int");

                    b.HasKey("InscriptionEntityId");

                    b.HasIndex("EncadreurEntityId");

                    b.HasIndex("HadjEntityId");

                    b.HasIndex("UsagerEntityId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PaiementEntity", b =>
                {
                    b.Property<int>("PaiementEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateversement")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscriptionEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.HasKey("PaiementEntityId");

                    b.HasIndex("InscriptionEntityId");

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PieceJointesEntity", b =>
                {
                    b.Property<int>("PieceJointesEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileNumerise")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<int>("InscriptionEntityId")
                        .HasColumnType("int");

                    b.Property<int>("PiecesTypeEntityId")
                        .HasColumnType("int");

                    b.Property<bool>("Qualite")
                        .HasColumnType("bit");

                    b.HasKey("PieceJointesEntityId");

                    b.HasIndex("InscriptionEntityId");

                    b.HasIndex("PiecesTypeEntityId");

                    b.ToTable("PieceJointes");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PiecesTypeEntity", b =>
                {
                    b.Property<int>("PiecesTypeEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PiecesTypeEntityId");

                    b.ToTable("PieceTypes");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.VolEntity", b =>
                {
                    b.Property<int>("VolEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datedepart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numvol")
                        .HasColumnType("int");

                    b.Property<int?>("VilleDepartVilleEntityId")
                        .HasColumnType("int");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.HasKey("VolEntityId");

                    b.HasIndex("VilleDepartVilleEntityId");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.VoyageEntity", b =>
                {
                    b.Property<int>("VoyageEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UsagerEntityId")
                        .HasColumnType("int");

                    b.Property<int>("VolEntityId")
                        .HasColumnType("int");

                    b.HasKey("VoyageEntityId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.DepartureTownEntity", b =>
                {
                    b.Property<int>("DepartureTownEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HadjEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UsagerEntityId")
                        .HasColumnType("int");

                    b.Property<int>("VilleEntityId")
                        .HasColumnType("int");

                    b.HasKey("DepartureTownEntityId");

                    b.HasIndex("VilleEntityId");

                    b.ToTable("VillesDepart");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.RegionEntity", b =>
                {
                    b.Property<int>("RegionEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeReg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomReg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionEntityId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.VilleEntity", b =>
                {
                    b.Property<int>("VilleEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomVille")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionEntityId")
                        .HasColumnType("int");

                    b.HasKey("VilleEntityId");

                    b.HasIndex("RegionEntityId");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.AgreementEntity", b =>
                {
                    b.Property<int>("AgreementEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datedebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datefin")
                        .HasColumnType("datetime2");

                    b.Property<int>("EncadreurEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgreementEntityId");

                    b.HasIndex("EncadreurEntityId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.EncadreurEntity", b =>
                {
                    b.Property<int>("EncadreurEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dtownn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PassportDel")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PassportExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncadreurEntityId");

                    b.ToTable("Encadreurs");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.HadjEntity", b =>
                {
                    b.Property<int>("HadjEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cout")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Datedebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datefin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.HasKey("HadjEntityId");

                    b.ToTable("Hadjs");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.SocieteEntity", b =>
                {
                    b.Property<int>("SociteEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EncadreurEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Hqter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rsoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SociteEntityId");

                    b.HasIndex("EncadreurEntityId");

                    b.ToTable("Societes");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.UsagerEntity", b =>
                {
                    b.Property<int>("UsagerEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PassportDel")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PassportExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Townn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsagerEntityId");

                    b.ToTable("Usagers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sih.Entities.Administration.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sih.Entities.Administration.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sih.Entities.Administration.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sih.Entities.Administration.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sih.Entities.Gestion.InscriptionEntity", b =>
                {
                    b.HasOne("Sih.Entities.Pelerins.EncadreurEntity", "Encadreur")
                        .WithMany("Inscriptions")
                        .HasForeignKey("EncadreurEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sih.Entities.Pelerins.HadjEntity", "Hadj")
                        .WithMany("Inscriptions")
                        .HasForeignKey("HadjEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sih.Entities.Pelerins.UsagerEntity", "Pelerin")
                        .WithMany()
                        .HasForeignKey("UsagerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encadreur");

                    b.Navigation("Hadj");

                    b.Navigation("Pelerin");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PaiementEntity", b =>
                {
                    b.HasOne("Sih.Entities.Gestion.InscriptionEntity", "Inscription")
                        .WithMany("Paiements")
                        .HasForeignKey("InscriptionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PieceJointesEntity", b =>
                {
                    b.HasOne("Sih.Entities.Gestion.InscriptionEntity", "Inscription")
                        .WithMany("PiecesJointes")
                        .HasForeignKey("InscriptionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sih.Entities.Gestion.PiecesTypeEntity", "PieceType")
                        .WithMany("PieceJointes")
                        .HasForeignKey("PiecesTypeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");

                    b.Navigation("PieceType");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.VolEntity", b =>
                {
                    b.HasOne("Sih.Entities.Localisation.VilleEntity", "VilleDepart")
                        .WithMany()
                        .HasForeignKey("VilleDepartVilleEntityId");

                    b.Navigation("VilleDepart");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.DepartureTownEntity", b =>
                {
                    b.HasOne("Sih.Entities.Localisation.VilleEntity", "VilleDepart")
                        .WithMany("Departures")
                        .HasForeignKey("VilleEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VilleDepart");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.VilleEntity", b =>
                {
                    b.HasOne("Sih.Entities.Localisation.RegionEntity", "Region")
                        .WithMany("Villes")
                        .HasForeignKey("RegionEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.AgreementEntity", b =>
                {
                    b.HasOne("Sih.Entities.Pelerins.EncadreurEntity", "Encadreur")
                        .WithMany("Agreements")
                        .HasForeignKey("EncadreurEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encadreur");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.SocieteEntity", b =>
                {
                    b.HasOne("Sih.Entities.Pelerins.EncadreurEntity", "CEO")
                        .WithMany("Socites")
                        .HasForeignKey("EncadreurEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CEO");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.InscriptionEntity", b =>
                {
                    b.Navigation("Paiements");

                    b.Navigation("PiecesJointes");
                });

            modelBuilder.Entity("Sih.Entities.Gestion.PiecesTypeEntity", b =>
                {
                    b.Navigation("PieceJointes");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.RegionEntity", b =>
                {
                    b.Navigation("Villes");
                });

            modelBuilder.Entity("Sih.Entities.Localisation.VilleEntity", b =>
                {
                    b.Navigation("Departures");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.EncadreurEntity", b =>
                {
                    b.Navigation("Agreements");

                    b.Navigation("Inscriptions");

                    b.Navigation("Socites");
                });

            modelBuilder.Entity("Sih.Entities.Pelerins.HadjEntity", b =>
                {
                    b.Navigation("Inscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
