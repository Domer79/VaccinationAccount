using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Concrete;
using Dal.EntityConfiguration;
using Dal.Migrations;

namespace Dal
{
    internal class VaccinationContext: DbContext
    {
        private readonly bool _databaseExists;

        public VaccinationContext()
        {
            if (_databaseExists || (_databaseExists = Database.Exists()))
                Database.SetInitializer(new ContainerInitializer());
            else
            {
                Database.SetInitializer(new VaccinationCreateDatabase());
            }

            Database.Initialize(false);
        }

        #region Init Database

        class VaccinationCreateDatabase: CreateDatabaseIfNotExists<VaccinationContext>
        {
            public override void InitializeDatabase(VaccinationContext context)
            {
                base.InitializeDatabase(context);
                var command = $"alter database {context.Database.Connection.Database} collate SQL_Latin1_General_CP1_CI_AS";
                context.Database.ExecuteSqlCommand(command);
            }
        }

        private class ContainerInitializer : MigrateDatabaseToLatestVersion<VaccinationContext, Configuration>
        {
        }

        #endregion

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VaccinationConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());
        }

        #region Helpers

        #endregion
    }
}
