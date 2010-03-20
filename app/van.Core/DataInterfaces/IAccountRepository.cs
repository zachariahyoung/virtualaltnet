using SharpArch.Core.PersistenceSupport;

namespace van.Core.DataInterfaces {

    public interface IAccountRepository : IRepository<Role>
    {
       string GetRoleForUser(string username);
    }
}
