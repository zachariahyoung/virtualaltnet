using System;
using Microsoft.Practices.ServiceLocation;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Web.Controllers.Infrastructure
{
    public class MembershipProvider : IMembershipProvider {
        private readonly IUserRepository userRepository;
        private readonly IAccountRepository accountRepository;

        public MembershipProvider(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
        }

        public MembershipProvider()
            : this(ServiceLocator.Current.GetInstance<IUserRepository>(),ServiceLocator.Current.GetInstance<IAccountRepository>())
        {
        }

        public bool ValidateUser(string userName, string password, out string validationMessage)
        {
            User user;
            try {
                user = userRepository.GetByUserName(userName);
                if (user == null) {
                    validationMessage = "invalid username";
                    return false;
                }

                if (user.Password != password) {
                    validationMessage = "invalid password";
                    return false;
                }
                validationMessage = "";
                return true;
            }
            catch (Exception ex) {
                throw new Exception("Encountered an error while attempting to validate username and password", ex);
            }

        }


        public bool AuthorizeUser(string userName, out string authorizationMessage)
        {
            try
            {
                User user = userRepository.GetByUserName(userName);
                Account account = accountRepository.GetRoleForUser(user.Id);

                if (account == null) {
                    authorizationMessage = "access is denied.";
                    return false;
                }
                if (account.Name == null ) authorizationMessage = "Access to this location is not allowed.";
                authorizationMessage = "Access to this location is allowed.";
                return true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Encountered an error while attempting to authorize username in a restricted area.", ex);
            }
            
        }
    }
}