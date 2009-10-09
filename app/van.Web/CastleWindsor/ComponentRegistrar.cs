using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.Castle;
using Castle.MicroKernel.Registration;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using van.ApplicationServices;
using van.Core.DataInterfaces;
using van.Data;
using van.Web.Controllers.Infrastructure;

namespace van.Web.CastleWindsor
{
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddApplicationServicesTo(container);
            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
            container.AddComponent("authenticationProvider",
                                   typeof(IAuthenticationProvider), typeof(FormsAuthenticationProvider));
            container.AddComponent("authorizationProvider",
                                   typeof(IAuthorizationProvider), typeof(FormsAuthenticationProvider));
            container.AddComponent("accountRepository",
                       typeof(IAccountRepository), typeof(AccountRepository));
            container.AddComponent("userRepository",
                                   typeof(IUserRepository), typeof(UserRepository));
            container.AddComponent("membershipProvider",
                                   typeof(IMembershipProvider), typeof(MembershipProvider));
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("van.Data")
                .WithService.FirstNonGenericCoreInterface("van.Core"));
        }
        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            container.Register(Component.For<IAggregator>().ImplementedBy<Aggregator>());
            container.Register(Component.For<INewsProvider>().ImplementedBy<BlogspotNewsProvider>());
            container.Register(Component.For<IEventProvider>().ImplementedBy<GoogleEventProvider>());

        }
        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType",
                typeof(IRepository<>), typeof(Repository<>));
            container.AddComponent("nhibernateRepositoryType",
                typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent("repositoryWithTypedId",
                typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent("nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>), typeof(NHibernateRepositoryWithTypedId<,>));
           
        }
    }
}
