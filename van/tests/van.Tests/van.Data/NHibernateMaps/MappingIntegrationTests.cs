using NUnit.Framework;
using SharpArch.Testing.NUnit.NHibernate;
using SharpArch.Data.NHibernate;
using System.Collections;
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
    [Ignore]
    [Category("DB Tests")]
    public class MappingIntegrationTests
    {
        [SetUp]
        public virtual void SetUp()
        {
            string[] mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(),
                "../../../../app/van.Web/NHibernate.config");
        }

        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            IDictionary allClassMetadata = NHibernateSession.SessionFactory.GetAllClassMetadata();
            Console.WriteLine("The number of Classes =" + allClassMetadata.Count);


            foreach (DictionaryEntry entry in allClassMetadata)
            {
                NHibernateSession.Current.CreateCriteria((Type)entry.Key)
                     .SetMaxResults(0).List();
            }
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
