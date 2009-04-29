using System;
using System.Collections;
using System.IO;
using van.Data.NHibernateMaps;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NUnit.NHibernate;

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
    [Ignore]
    public class MappingIntegrationExportSchemaTests {
        #region Setup/Teardown

        [SetUp]
        public virtual void SetUp()
        {
            GetDatabaseCfg(true);
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (NHibernateSession.Storage.Session != null)
            {
                NHibernateSession.Storage.Session.Dispose();
            }
        }

        #endregion

        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            var allClassMetadata = NHibernateSession.SessionFactory.GetAllClassMetadata();
            Console.WriteLine("The number of Classes =" + allClassMetadata.Count);

            foreach (DictionaryEntry entry in allClassMetadata)
            {
              
                NHibernateSession.Current.CreateCriteria((Type)entry.Key)
                    .SetMaxResults(0).List();
            }
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
            var mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            Console.WriteLine("The entity map type is =" + mappingAssemblies.GetType());
            return useLiveDb
                       ? NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                                                new AutoPersistenceModelGenerator().Generate(),
                                                LIVE_DB_CONFIG_PATH)
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
    }
}