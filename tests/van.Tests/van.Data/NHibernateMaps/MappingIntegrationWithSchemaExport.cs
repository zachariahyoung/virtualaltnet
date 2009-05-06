using System.IO;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using van.Data.NHibernateMaps;
using NUnit.Framework;
using SharpArch.Testing.NUnit.NHibernate;
using SharpArch.Data.NHibernate;
using NHibernate;
using System.Collections.Generic;
using NHibernate.Metadata;

namespace Tests.van.Data.NHibernateMaps
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// 
    /// Additional Schema updates added thanks to Marten at S#harp Architecture 
    /// http://groups.google.com/group/sharp-architecture/browse_thread/thread/6ba7ceb41bd69ed9
    /// </summary>
    [TestFixture]
    [Category("DB Tests")]
    public class MappingIntegrationTests {
        #region Setup/Teardown

        [SetUp]
        public virtual void SetUp()
        {
            GetDatabaseCfg(false);

        }

        [TearDown]
        public virtual void TearDown()
        {  
            if (NHibernateSession.Storages[FACTORY_KEY].Session != null) {
                NHibernateSession.Storages[FACTORY_KEY].Session.Dispose();
            }

            NHibernateSession.SessionFactory = null;
            NHibernateSession.Storage = null;
        }
         
        #endregion

        /*
        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            IDictionary<string, IClassMetadata> allClassMetadata =
                NHibernateSession.SessionFactories[FACTORY_KEY].GetAllClassMetadata();

            foreach (KeyValuePair<string, IClassMetadata> entry in allClassMetadata)
            {
                NHibernateSession.CurrentFor(FACTORY_KEY).CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                     .SetMaxResults(0).List();
            }
        }
         */

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
            PrepareSchemaExport(true).Execute(true, false, false, true, null,
                new StreamWriter(DB_FOLDER_PATH + "DbSchema.sql"));
        }

        [Test]
        public void UpdateLiveDbSchema()
        {
            PrepareSchemaUpdate(true).Execute(true, true);
        }

        private static Configuration GetDatabaseCfg(bool useLiveDb)
        {
            NHibernateSession.SessionFactory = null;
            NHibernateSession.Storage = null;

            var mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            return useLiveDb
                       ? NHibernateSession.Init(new SimpleSessionStorage(FACTORY_KEY), mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(), LIVE_DB_CONFIG_PATH)
                       :
                           NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                                                  new AutoPersistenceModelGenerator().Generate());
        }

        private static SchemaExport PrepareSchemaExport(bool useLiveDb)
        {
            return new SchemaExport(GetDatabaseCfg(useLiveDb));
        }

        private static SchemaUpdate PrepareSchemaUpdate(bool useLiveDb)
        {
            return new SchemaUpdate(GetDatabaseCfg(useLiveDb));
        }

        private const string LIVE_DB_CONFIG_PATH = "../../../../app/van.Web/NHibernate.config";
        private const string DB_FOLDER_PATH = "../../../../db/";
        private const string FACTORY_KEY = "nhibernate.tests_using_live_database";
    }
}