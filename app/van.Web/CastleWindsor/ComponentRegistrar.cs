using Castle.Windsor;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.Castle;
using Castle.MicroKernel.Registration;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using Rhino.Commons;


namespace van.Web.CastleWindsor {
    /// <summary>
    /// 
    /// </summary>
    public class ComponentRegistrar {
        /// <summary>
        /// Adds the components to.
        /// </summary>
        /// <param name="container">Add dependencies to the Windsor IOC container.</param>
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddRhinoSecurityComponentsTo(container);
            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("van.Data")
                .WithService.FirstNonGenericCoreInterface("van.Core"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType", typeof(SharpArch.Core.PersistenceSupport.IRepository<>),
            typeof(SharpArch.Data.NHibernate.Repository<>));
            container.AddComponent("nhibernateRepositoryType",
                typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent("repositoryWithTypedId",
                typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent("nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>), typeof(NHibernateRepositoryWithTypedId<,>));
        }

        private static void AddRhinoSecurityComponentsTo(IWindsorContainer container)
        {
            container.AddComponent("rhinoRepositoryType", typeof(Rhino.Commons.IRepository<>), typeof(NHRepository<>));
            container.AddComponent("unitOfWorkFactoryType", typeof(IUnitOfWorkFactory), typeof(NHibernateUnitOfWorkFactory));
        }
    }
}
