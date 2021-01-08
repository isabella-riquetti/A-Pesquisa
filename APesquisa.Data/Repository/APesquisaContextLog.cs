using APesquisa.Data.Models;
using APesquisa.Data.Models.Mapping;
using APesquisa.Data.Programmability.Functions;
using APesquisa.Data.Programmability.Stored_Procedures;
using System;
using System.Configuration;
using System.Data.Entity;

namespace APesquisa.Data.Repository
{
    public class APesquisaContextLog : DbContext
    {
        public static string GetConnectionString(string connectionString)
        {
            var azureFunctionsConnection = Environment.GetEnvironmentVariable(connectionString);
            var defaultConnection = ConfigurationManager.ConnectionStrings[connectionString]?.ConnectionString;

            return defaultConnection ?? azureFunctionsConnection ?? connectionString;
        }

        public APesquisaContextLog(string contextName) : base(GetConnectionString(contextName))
        {
            StoredProcedures = new StoredProcedures(this);
            ScalarValuedFunctions = new ScalarValuedFunctions(this);
            TableValuedFunctions = new TableValuedFunctions(this);
        }

        public DbSet<Component> Component { get; set; }
        //public DbSet<MergeTable> MergeTable { get; set; }

        public StoredProcedures StoredProcedures { get; set; }
        public ScalarValuedFunctions ScalarValuedFunctions { get; set; }
        public TableValuedFunctions TableValuedFunctions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ComponentMap());
            //modelBuilder.Configurations.Add(new MergeTableMap());
        }
    }
}
