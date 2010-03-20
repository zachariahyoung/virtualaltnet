using SharpArch.Core.PersistenceSupport;

namespace van.Core.DataInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string username);
        
    }
}