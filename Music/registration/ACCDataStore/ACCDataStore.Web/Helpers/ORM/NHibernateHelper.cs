using ACCDataStore.Entity.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace ACCDataStore.Web.Helpers.ORM
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var sUid = System.Configuration.ConfigurationManager.AppSettings["Uid"];
            var sPwd = System.Configuration.ConfigurationManager.AppSettings["Pwd"];
            var sDbName = System.Configuration.ConfigurationManager.AppSettings["dbName"];
            var sDbHost = System.Configuration.ConfigurationManager.AppSettings["dbHost"];
            var sDbType = System.Configuration.ConfigurationManager.AppSettings["dbType"];
            var sDbPort = System.Configuration.ConfigurationManager.AppSettings["dbPort"];

            string sConnectionString;
            global::NHibernate.Cfg.Configuration configuration;

            switch (sDbType)
            {
                case "2":
                    sConnectionString = @"Server=" + sDbHost + ";Initial Catalog=" + sDbName + ";User Id=" + sUid + ";Password=" + sPwd;
                    configuration = Fluently
                        .Configure()
                        .Database(MsSqlConfiguration
                            .MsSql2012
                            .ConnectionString(sConnectionString)
                            .ShowSql
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildConfiguration();
                    break;
                case "3":
                    configuration = Fluently
                        .Configure()
                        .Database(
                            SQLiteConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("SQLiteConnectionString")))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                        .BuildConfiguration();
                    break;
                default:
                    sConnectionString = @"Server =" + sDbHost + ";Port=" + sDbPort + ";Database=" + sDbName + ";User ID=" + sUid + ";Password=" + sPwd + ";convert zero datetime=True";
                    configuration = Fluently
                        .Configure()
                        .Database(MySQLConfiguration
                            .Standard
                            .ConnectionString(sConnectionString)
                            .ShowSql
                        )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildConfiguration();
                    break;
            }

            return configuration.BuildSessionFactory();
        }
    }
}
