using Castle.Windsor;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using SharpArch.Core.PersistenceSupport;
using Tests.van.Data.TestDoubles;
using van.Core.DataInterfaces;
using van.Data;
using van.Web.Controllers.Infrastructure;

namespace Tests
{
    public class ServiceLocatorInitializer
    {
        public static void Init()
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateCheckerStub));
            container.AddComponent("authenticationProvider",
                                    typeof(IAuthenticationProvider), typeof(FormsAuthenticationProvider));
            container.AddComponent("authorizationProvider",
                                   typeof(IAuthorizationProvider), typeof(FormsAuthenticationProvider));
            container.AddComponent("userRepository",
                                   typeof(IUserRepository), typeof(UserRepository));
            container.AddComponent("accountRepository",
                       typeof(IAccountRepository), typeof(AccountRepository));
            container.AddComponent("membershipProvider",
                                   typeof(IMembershipProvider), typeof(MembershipProvider));
 

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
