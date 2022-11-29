using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sih.Entities.Administration;
using Sih.Entities.Gestion;
using Sih.Entities.Localisation;
using Sih.Entities.Pelerins;
using System;
using System.IO;

namespace Sih.Persistence.Configurations
{
    public class SihDbContext : IdentityDbContext<UserEntity>
    {

        private const string ConnectionStringName = "DefaultConnection";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public SihDbContext(DbContextOptions<SihDbContext> options) : base(options)
        {
        }

        //Debut tables de la base de données
        //
        //
        //Administration
        //UserEntity est Géré par l'héritage de Identity
        public DbSet<NotificationsEntity> Notifications { get; set; }
        //
        //
        //Enums
        //Les enumerations (MesEnums) sont géréses en tant que colonnes des tables
        //
        //
        //Gestion
        public DbSet<AvionEntity> Avions { get; set; }
        public DbSet<InscriptionEntity> Inscriptions { get; set; }
        public DbSet<PaiementEntity> Paiements { get; set; }
        public DbSet<PieceJointesEntity> PieceJointes { get; set; }
        public DbSet<PiecesTypeEntity> PieceTypes { get; set; }
        public DbSet<VolEntity> Vols { get; set; }
        public DbSet<VoyageEntity> Voyages { get; set; }
        //
        //
        //Localisation
        public DbSet<DepartureTownEntity> VillesDepart { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<VilleEntity> Villes { get; set; }
        //
        //
        //Pelerins
        public DbSet<AgreementEntity> Agreements { get; set; }
        public DbSet<EncadreurEntity> Encadreurs { get; set; }
        public DbSet<HadjEntity> Hadjs { get; set; }
        public DbSet<SocieteEntity> Societes { get; set; }
        public DbSet<UsagerEntity> Usagers { get; set; }
        //
        //
        //Fin tables de la base de données

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("", Path.DirectorySeparatorChar);
            var environmentName = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(basePath)
                                    .AddJsonFile("appsettings.json")
                                    .AddEnvironmentVariables()
                                    .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
