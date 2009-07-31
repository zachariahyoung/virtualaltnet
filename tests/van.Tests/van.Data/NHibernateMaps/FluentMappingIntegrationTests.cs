using System.IO;
using SharpArch.Testing.NHibernate;
using van.Data.NHibernateMaps;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SharpArch.Data.NHibernate;


namespace Tests.van.Data.NHibernateMaps
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [Category("DB Schema Tests")]
    public class FluentMappingIntegrationTests
    {
        private static Configuration _nhConfig;
        
        [SetUp]
        public virtual void SetUp()
        {
            NHibernateSession.SessionFactory = null;
            NHibernateSession.Storage = null;

            var mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            _nhConfig = NHibernateSession.Init(new SimpleSessionStorage(FACTORY_KEY), mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(),
                TEST_DB_CONFIG_PATH);
        }
                
        [Test]
        public void WriteMappingsToFile()
        {
            var mappings = new AutoPersistenceModelGenerator().Generate();
            mappings.CompileMappings();
            mappings.WriteMappingsTo(DB_FOLDER_PATH);
        }

        [Test]
        public void ExportSchemaToFile()
        {
            PrepareSchemaExport().Execute(true, false, false, null, new StreamWriter(DB_FOLDER_PATH + "DbSchema.sql"));
        }

       private static SchemaExport PrepareSchemaExport()
        {
            return new SchemaExport(_nhConfig);
        }

        //private static SchemaUpdate PrepareSchemaUpdate(bool useLiveDb)
        //{
        //    return new SchemaUpdate(GetDatabaseCfg(useLiveDb));
        //}

        private const string TEST_DB_CONFIG_PATH = "../../../../tests/van.Tests/HibernateSQL5.cfg.xml";
        private const string DB_FOLDER_PATH = "../../../../db/";

        [TearDown]
        public virtual void TearDown()
        {
            if (NHibernateSession.Storages[FACTORY_KEY].Session != null) {
                NHibernateSession.Storages[FACTORY_KEY].Session.Dispose();
            }

            NHibernateSession.SessionFactory = null;
            NHibernateSession.Storage = null;
        }

        private const string FACTORY_KEY = "nhibernate.current_session";
    }

}