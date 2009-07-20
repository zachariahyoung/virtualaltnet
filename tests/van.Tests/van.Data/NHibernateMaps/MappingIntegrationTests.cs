using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SharpArch.Testing.NUnit.NHibernate;
using SharpArch.Data.NHibernate;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Metadata;
using System;
using van.Data.NHibernateMaps;

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
    [Category("DB Tests")]
    public class MappingIntegrationTests
    {
        private Configuration _cfg;

     
        [SetUp]
        public virtual void SetUp()
        {
            var mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            _cfg = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(),
                "../../../../app/van.Web/NHibernate.config");
          
        }
        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            IDictionary<string, IClassMetadata> _cfg = NHibernateSession.SessionFactory.GetAllClassMetadata();
           foreach (KeyValuePair<string, IClassMetadata> entry in _cfg)
            {
                NHibernateSession.Current.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                     .SetMaxResults(0).List();
            }
            //var export = new SchemaExport(_cfg as Configuration);
            //export.Execute(true, false, false, false, NHibernateSession.Current.Connection, null);
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (NHibernateSession.Storage.Session != null)
            {
                NHibernateSession.Storage.Session.Dispose();
            }
        }
    }
}
