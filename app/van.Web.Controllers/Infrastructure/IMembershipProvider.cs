namespace van.Web.Controllers.Infrastructure
{
    public interface IMembershipProvider {

        bool ValidateUser(string userName, string password, out string validationMessage);
        bool AuthorizeUser(string userName, out string authorizationMessage);
    }
}